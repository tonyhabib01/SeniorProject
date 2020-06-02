using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymApplication.Models
{
    public class Earning
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Profit { get; set; }
        public DateTime Datetime { get; set; }
    }
}