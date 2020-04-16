using GymApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymApplication.Controllers
{
    public class PurchasesController : Controller
    {
        private ApplicationDbContext _context;
        public PurchasesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Purchases
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult InvoiceSearch()
        {
            var invoices = _context.Invoices.ToList();
            return View(invoices);
        }
    }
}