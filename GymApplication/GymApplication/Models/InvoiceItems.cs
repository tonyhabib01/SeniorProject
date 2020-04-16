using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GymApplication.Models
{
    public class InvoiceItems
    {
        public int Id { get; set; }

        //[ForeignKey("Invoice"), Column(Order = 0)]
        //public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }


        //[ForeignKey("Item"), Column(Order = 1)]
        //public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}