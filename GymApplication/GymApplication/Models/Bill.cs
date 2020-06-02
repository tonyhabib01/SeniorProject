using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymApplication.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Datetime { get; set; }
    }
}