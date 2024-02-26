using CsvHelper.Configuration.Attributes;
using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Windows.Forms;

//Create new class for database context
public class StockContext : DbContext
{
    public DbSet<Stock> Stocks { get; set; }    //Table containing Stock classes
    public DbSet<SmartStock> SmartStocks { get; set; }
    public string DbPath { get; }               //Path to the database
    public string StockPath { get; set; }       //Path to the Stock Files folder

    public StockContext()                               //Constructor for StockContext
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;    //Get folder name for data
        var path = Environment.GetFolderPath(folder);                   //Get path to folder
        //DbPath = System.IO.Path.Join(path, "Stocks.db");                //Update path variable to folder + name for database
        string mypath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);    //Get path to exe location

        
        if (mypath != null)
        {
            mypath = mypath.Substring(0, mypath.LastIndexOf("COP4365_Project3\\") + "COP4365_Project3".Length+1);
            DbPath = Path.Join(mypath, "Stocks.db");                //Update path variable to folder + name for database
            //Get substring of path to solution folder, then add "\Stock Data". Save as StockPath.
            mypath = mypath.Substring(0, mypath.LastIndexOf("COP4365_Project3"));
            mypath += "Stock Data";
            StockPath = mypath;
        }
        else
        {
            Debug.WriteLine("FAILED TO GET CURRENT DIRECTORY");
            return;
        }
    }
    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Stock                             //Stock class containing all information for stock
{
    //Ignore so that the csvReader does not try and use it as a column to read into. Key marks as unique identifier for entry.
    [Ignore][Key] public Guid Id { get; set; }              //Identifier for Stock entry.
    public DateTime Date { get; set; }                      //Date of stock (DateTime format)
    public string Ticker { get; set; }                      //Stock Ticker (Three/four letter string)
    public string Period { get; set; }                      //Timespan for the stock (month/week/day)
    public double Open { get; set; }                        //Open value for stock (Dollars-Cents)
    public double High { get; set; }                        //High value for stock (Dollars-Cents)
    public double Low { get; set; }                         //Low value for stock (Dollars-Cents)
    public double Close { get; set; }                       //Close value for stock (Dollars-Cents)
    //Needs to be 64-bit, numbers get too large for signed 32-bit
    public Int64 Volume { get; set; }                       //Volume value for stock (Int count)
    [Ignore] public string StockFilePath { get; set; }      //Path to file
}

public class SmartStock : Stock
{
    public SmartStock() { }
    public SmartStock(Stock stock)
    {
        // Copy properties from Stock to SmartStock
        Id = stock.Id;
        Date = stock.Date;
        Ticker = stock.Ticker;
        Period = stock.Period;
        Open = stock.Open;
        High = stock.High;
        Low = stock.Low;
        Close = stock.Close;
        Volume = stock.Volume;
        StockFilePath = stock.StockFilePath;

        TopPrice = Math.Max(stock.Open, stock.Close);
        BottomPrice = Math.Min(stock.Open, stock.Close);
        BodyRange = Math.Abs(stock.Open - stock.Close);
        TopTail = stock.High - Math.Max(stock.Open, stock.Close);
        BottomTail = Math.Min(stock.Open, stock.Close) - stock.Low;
    }
    public double TopPrice { get; set; }                    //Max open & close 
    public double BottomPrice { get; set; }                 //Min open & close
    public double BodyRange { get; set; }
    public double TopTail { get; set; }
    public double BottomTail { get; set; }
    public bool IsBullish { get; set; } = false;
    public bool IsBearish { get; set; } = false;
    public bool IsNeutral { get; set; } = false;
    public bool IsMarubozu { get; set; } = false;
    public bool IsDoji { get; set; } = false;
    public bool IsDragonFlyDoji { get; set; } = false;
    public bool IsGravestoneDoji { get; set; } = false;
    public bool IsHammer { get; set; } = false;
    public bool IsInvertedHammer { get; set; } = false;
}