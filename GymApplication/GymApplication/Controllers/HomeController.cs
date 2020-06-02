using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GymApplication.Models;

namespace GymApplication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            //double userProfit = 0;
            //var invoices = _context.Invoices.ToList();
            //var users = _context.Users.Include(u=>u.MembershipType).ToList();

            //foreach (var user in users)
            //{
            //    userProfit += user.MembershipType.MembershipFees;
            //}
            return View();
        }

        //public double MonthlyEarning()
        //{
        //    double earnings = 0;
        //    var users = _context.Users.Include(u => u.MembershipType).Where(u => u.RegistrationDate.Month == DateTime.Now.Month);
        //    var invoices = _context.Invoices.Where(u => u.InvoiceDateTime.Value.Month == DateTime.Now.Month);
        //    //add bills
        //    foreach (var user in users)
        //        earnings += user.MembershipType.MembershipFees;

        //    foreach (var invoice in invoices)
        //        earnings += invoice.Profit;

        //    return earnings;
            
        //}

        //public double YearlyEarning()
        //{
        //    double earnings = 0;
        //    var users = _context.Users.Include(u => u.MembershipType).Where(u => u.RegistrationDate.Year == DateTime.Now.Year);
        //    var invoices = _context.Invoices.Where(u => u.InvoiceDateTime.Value.Year == DateTime.Now.Month);
        //    //add bills
        //    foreach (var user in users)
        //        earnings += user.MembershipType.MembershipFees;

        //    foreach (var invoice in invoices)
        //        earnings += invoice.Profit;

        //    return earnings;
        //}
    }
}