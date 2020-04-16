using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymApplication.Models
{
    public class Class
    {
        public int Id { get; set; }

        [Display(Name = "Class Name")]
        public string Name { get; set; }
        
        [Display(Name = "Class Day")]
        public string Day { get; set; }

        [Display(Name = "Class Time")]
        public string StartTime { get; set; }

        public string EndTime { get; set; }


    }
}