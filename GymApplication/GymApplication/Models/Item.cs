using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymApplication.Models
{
    public class Item
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }

        [Display(Name = "Retail Price")]
        public double RetailPrice { get; set; }

        [Display(Name = "Actual Price")]
        public double ActualPrice { get; set; }

        [Display(Name ="Stock Number")]
        public int StockNumber { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}