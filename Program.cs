using System.Diagnostics;
using CsvHelper;
using System.Globalization;

namespace COP4365_Project2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Create Database
            InitDatabase();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form_Entry());
        }
        static void InitDatabase()
        {
            //Create new StockContext
            StockContext db = new StockContext();
            Debug.WriteLine($"Database path: {db.DbPath}.");
            //Removed the automatic loading of the entire folder into the database, due to speed and
            //error avoidance reasons.
        }
    }
}