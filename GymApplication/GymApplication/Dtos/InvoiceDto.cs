using GymApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymApplication.Dtos
{
    public class InvoiceDto
    {
        public List<int> ItemIds { get; set; }
        public double TotalPrice { get; set; }
    }
}