using CsvHelper;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Globalization;

namespace COP4365_Project2
{
    public partial class Form_Entry : Form
    {
        StockContext db = new StockContext();
        public Form_Entry()
        {
            //When the form is closed, it will delete all entries in the database
            StockContext db = new StockContext();
            FormClosed += new FormClosedEventHandler(Form_entry_FormClosed);
            void Form_entry_FormClosed(object sender, FormClosedEventArgs e)
            {
                Debug.WriteLine("DELETE DB");
                //Iterate through the database, deleting entries, then save changes
                foreach (var item in db.Stocks) { db.Stocks.Remove(item); }
                db.SaveChanges();
            }

            InitializeComponent();
        }

        private void button_loadStocks_Click(object sender, EventArgs e)
        {
            //Show openFileDialog
            openFileDialog_stocks.ShowDialog();
        }

        private void openFileDialog_stocks_FileOk(object sender, CancelEventArgs e)
        {
            //Get from and to date from pickers. Check if from date is before to date.
            var startDate = dateTimePickerStart.Value;
            var endDate = dateTimePickerEnd.Value;
            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be after End date. ");
                return;
            }

            //Get the filepath from the selected item.
            var filePaths = openFileDialog_stocks.FileNames;
            Debug.WriteLine($"{filePaths}");

            //Because the stock files may not be found due to a moved folder, the option to include
            //stocks upon loading a new file must be included.
            //For every selected file, create a reader for the csv, read into records, place records into database.
            foreach (var file in filePaths)
            {
                var reader = new StreamReader(file);
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<Stock>();
                foreach (var item in records)
                {
                    //Add the path to the item, check if the stock exists in the db already, if not add it.
                    item.StockFilePath = file;
                    SmartStock smartItem = new SmartStock(item);
                    if (!db.SmartStocks.Any(s => (s.Date == item.Date) && (s.Ticker == item.Ticker) && (s.Period == item.Period)))
                        smartItem = findProperties(smartItem);
                    db.Stocks.Add(smartItem);
                }
            }
            db.SaveChanges();

            //For each file in Filepaths, create a list of stocks matching the filepath and create a chart_form for them
            foreach (var file in filePaths)
            {
                BindingList<SmartStock> boundStocks = new BindingList<SmartStock>();
                var stocks = db.SmartStocks.Where(s => s.StockFilePath == file);

                //Save all stocks into the boundStocks bindinglist.
                foreach (var stock in stocks)
                {
                    boundStocks.Add(stock);
                }

                //Create chart and show
                Chart_Form newChart = new Chart_Form(boundStocks, startDate, endDate);
                newChart.Show();
                Debug.WriteLine("TEST");
            }
        }
        public SmartStock findProperties(SmartStock item)
        {
            var bodyTolerance = (item.High - item.Low) * 0.10;        //10% tolerance
            if (item.Close - item.Open - bodyTolerance > 0)         //stock is bullish
                item.IsBullish = true;
            else if (item.Open - item.Close - bodyTolerance > 0)    //Stock is bearish
                item.IsBearish = true;
            else                                                    //Stock is neutral
                item.IsNeutral = true;
            if (item.TopTail < bodyTolerance && item.BottomTail < bodyTolerance)    //Stock is Marubozu
                item.IsMarubozu = true;
            if (item.TopPrice - item.BottomPrice < bodyTolerance)           //Stock is doji
                item.IsDoji = true;
            if (item.IsDoji && item.High - item.TopPrice < bodyTolerance*2 && //Stock is dragonfly doji
                item.BottomPrice - item.Low > bodyTolerance*3)
                item.IsDragonFlyDoji = true;
            if (item.IsDoji && item.High - item.TopPrice > bodyTolerance*3 &&   //Stock is Gravestone Doji
                item.BottomPrice - item.Low < bodyTolerance*2)
                item.IsGravestoneDoji = true;
            if (!item.IsDoji && item.TopPrice - item.BottomPrice < bodyTolerance * 4 && //Stock is Hammer
                item.High - item.TopPrice < bodyTolerance && item.BottomPrice - item.Low > bodyTolerance)
                item.IsHammer = true;
            if (!item.IsDoji && item.TopPrice - item.BottomPrice < bodyTolerance * 4 && //Stock is Inverted Hammer
                item.High - item.TopPrice > bodyTolerance && item.BottomPrice - item.Low < bodyTolerance)
                item.IsInvertedHammer = true;
            return item;
        }
    }
}
