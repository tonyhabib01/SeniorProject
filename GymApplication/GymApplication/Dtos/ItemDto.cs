using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymApplication.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }

        public double RetailPrice { get; set; }

        public double ActualPrice { get; set; }

        public int StockNumber { get; set; }
    }
}