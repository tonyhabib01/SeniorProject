using GymApplication.Dtos;
using GymApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymApplication.Controllers.api
{
    public class PurchasesController : ApiController
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

        //GET: /api/purchases
        public IEnumerable<Invoice> GetItems()
        {
            var invoices = _context.Invoices.ToList();

            return invoices;
        }


        //POST: /api/purchases
        [HttpPost]
        public IHttpActionResult CreateNewInvoice (InvoiceDto ItemIds)
        {
            //Load items that match the items sent in the request
            var items = _context.Items.Where(i => ItemIds.ItemIds.Contains(i.Id)).ToList();

            //List<Item> itemList = new List<Item>();
            //foreach (var item in ItemIds.ItemIds)
            //{
            //    itemList.Add(items.SingleOrDefault(i => i.Id == item));

            //}


            //Make Invoice Available to grab his id
            var invoice = new Invoice()
            {
                InvoiceDateTime = DateTime.Now,
                TotalPrice = ItemIds.TotalPrice
                //Items = itemList
                
            };


            _context.Invoices.Add(invoice); // Adding the invoice into the database


            //Accessing the items list to initialize the Associative class between the Item and Invoice
            foreach (var item in ItemIds.ItemIds)
            {// loading the associative table
                var itemInDb = _context.Items.SingleOrDefault(i => i.Id == item);
                if (itemInDb == null)
                    return BadRequest("No Item For Checkout");
                if (itemInDb.StockNumber == 0)
                    return BadRequest(itemInDb.Name + " Not Available in Stock");
                itemInDb.StockNumber--;

                //_context.SaveChanges();
                var invoiceItems = new InvoiceItems
                {
                    Invoice = invoice,
                    Item = items.SingleOrDefault(i=>i.Id == item)

                    
                };

                //_context.Invoices.Add(invoice);
                _context.InvoiceItems.Add(invoiceItems); // adding each row to the database
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
