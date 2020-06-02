using GymApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymApplication.Controllers
{
    public class BillsController : Controller
    {
        private ApplicationDbContext _context;
        public BillsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Bills
        public ActionResult Index()
        {
            var bills = _context.Bills.ToList();
            return View(bills);
        }

        public ActionResult AddBill()
        {
            ViewBag.TitleName = "Add Bill";
            return View();
        }

        public ActionResult EditBill(int id)
        {
            ViewBag.TitleName = "Edit Bill";
            var bill = _context.Bills.SingleOrDefault(b => b.Id == id);

            if (bill == null)
                return HttpNotFound();

            else
                return View("AddBill", bill);
        }
        //GET
        public ActionResult DeleteBill(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var bill = _context.Bills.Find(id);

            if (bill == null)
                return HttpNotFound();

            return View();
        }
        //POST
        [HttpPost]
        public ActionResult DeleteBill(int id)
        {
            var earnings = _context.Earnings.ToList();
            foreach (var earning in earnings)
            {
                if(earning.Name.Substring(0,11) == "Create Bill")
                {
                    if(earning.Name.Substring(13) == id.ToString())
                    {
                        _context.Earnings.Remove(earning);
                        break;
                    }

                }
            }
            var user = _context.Bills.Find(id);
            _context.Bills.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "Bills");
        }
        [HttpPost]
        public ActionResult Save(Bill bill)
        {
            
            if (bill.Id == 0)
            {
                var earning = new Earning
                {
                    Name = "Create Bill #" + bill.Id.ToString(),
                    Profit = bill.Price * (-1),
                    Datetime = DateTime.Now
                };
                bill.Datetime = DateTime.Now;
                _context.Bills.Add(bill);
            }

            else
            {
                var billInDb = _context.Bills.Single(b => b.Id == bill.Id);

                billInDb.Name = bill.Name;
                billInDb.Price = bill.Price;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Bills");
        }
    }
}