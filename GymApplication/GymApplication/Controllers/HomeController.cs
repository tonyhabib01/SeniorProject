using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GymApplication.Models;
using GymApplication.ViewModels;

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
            var earnings = _context.Earnings.ToList();
            var viewModel = new DashboardViewModel(earnings);
            return View(viewModel);
        }
    }
}