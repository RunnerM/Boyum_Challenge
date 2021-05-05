using System;
using System.Globalization;
using Boyum_Challenge.Data;
using Boyum_Challenge.Model;

namespace Boyum_Challenge.ViewModel
{
    /// <summary>
    /// Logic for MainWindow
    /// </summary>
    public class MainViewModel
    {
        private IDataService _dataService;
        public string FileName { get; set; }

        public WebOrder Order()
        {
            return _dataService.GetOrder();
        }
        public MainViewModel()
        {
            _dataService = new DataService();
        }

        /// <summary>
        /// Formatting doubles to display according to danish format. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FormatDouble(double input)
        {
            double Truncated = Math.Truncate(input * 100) / 100;
            CultureInfo ci = new CultureInfo("dk-Dk");
            return string.Format(ci, "{0:n}", Truncated);
        }

        /// <summary>
        /// Formatting Dates according to specifications
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FormatDate(DateTime input)
        {
            return input.ToString("dd. MMMM. yyyy");
        }
        
        public void ProcessFile()
        {
            _dataService.ReadOrderFromXml(FileName);
        }

        
    }
}