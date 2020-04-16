using GymApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GymApplication.ViewModels
{
    public class AddClassForm
    {
        public Class Class { get; set; }
        public IEnumerable<string> Days {

            get {

                return new List<string> {"Monday", "Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"};
            }
        
        }
        public IEnumerable<string> StartTimes { 
            get {
                List<string> snumb = new List<string>();
                for (int i = 0; i<=24; i++)
                {
                    if (i < 10)
                        snumb.Add("0" + i.ToString() + ":00") ;
                    else
                        snumb.Add(i.ToString() +":00");
                };

                return snumb;
            
            } 
        }
    }
}