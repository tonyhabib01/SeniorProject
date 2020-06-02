using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymApplication.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public DateTime? InvoiceDateTime { get; set; }
        public double TotalPrice { get; set; }
        public double Profit { get; set; }


    }
}