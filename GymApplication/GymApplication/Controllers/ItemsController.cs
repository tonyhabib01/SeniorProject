using GymApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GymApplication.Controllers
{
    public class ItemsController : Controller
    {

        //Connection to Database

        private ApplicationDbContext _context;
        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Items/Stock
        public ActionResult Stock()
        {
            var items = _context.Items.ToList();

            return View(items);
        }

        //Get: Items/AddItem
        public ActionResult AddItem()
        {
            ViewBag.Title = "Add Item";
            return View();
        }

        //Get: /Items/EditItem/id
        public ActionResult EditItem(int id)
        {
            ViewBag.Title = "Edit Item";
            var item = _context.Items.SingleOrDefault(i => i.Id == id);

            if (item == null)
                return HttpNotFound();

            else
                return View("AddItem",item);
        }

        //Get: /Items/DeleteItem/id
        public ActionResult DeleteItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _context.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: /Items/DeleteItem/5
        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            var item = _context.Items.Find(id);
            _context.Items.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Stock", "Items");
        }

        //POST: Save the ADD/EDIT Item Form (submit)
        [HttpPost]
        public ActionResult Save(Item item)
        {
            if (item.Id == 0)
            {
                _context.Items.Add(item);
            }

            else
            {
                var itemInDb = _context.Items.Single(i => i.Id == item.Id);

                itemInDb.Barcode = item.Barcode;
                itemInDb.Name = item.Name;
                itemInDb.RetailPrice = item.RetailPrice;
                itemInDb.ActualPrice = item.ActualPrice;
                itemInDb.StockNumber = item.StockNumber;
            }

            _context.SaveChanges();
            return RedirectToAction("Stock", "Items");
        }
        public IEnumerable<Item> GetItems()
        {
            var items = new List<Item>{
                new Item {Id = 1 , Name = "Master Chips", Barcode = "5283003301816", StockNumber = 50 , RetailPrice = 1.0 , ActualPrice = 1.5},
                new Item {Id = 2 , Name = "Klatchi Nuts", Barcode = "5287000845106", StockNumber = 16 , RetailPrice = 1.3 , ActualPrice = 2}
            };

            return items;
        }
    }
}