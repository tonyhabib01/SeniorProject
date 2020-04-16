using AutoMapper;
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
    public class ItemsController : ApiController
    {
        private ApplicationDbContext _context;
        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/items
        public IEnumerable<ItemDto> GetItems()
        {
            return _context.Items.ToList().Select(Mapper.Map<Item,ItemDto>);
        }

        //GET /api/items/1
        public IHttpActionResult GetItems (int id)
        {
            var item = _context.Items.SingleOrDefault(i => i.Id == id);

            if (item == null)
                return NotFound();

            return Ok(Mapper.Map<Item,ItemDto>(item));
        }

        //POST /api/items
        [HttpPost]
        public IHttpActionResult CreateItem (ItemDto itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var item = Mapper.Map<ItemDto, Item>(itemDto);
            _context.Items.Add(item);
            _context.SaveChanges();
            itemDto.Id = item.Id;
            return Created(new Uri(Request.RequestUri + "/" + item.Id), itemDto);
        }

        //PUT /api/items/1
        [HttpPut]
        public void UpdateCustomer (int id , ItemDto itemDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var itemInDb = _context.Items.SingleOrDefault(i => i.Id == id);

            if (itemInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(itemDto, itemInDb);


            _context.SaveChanges();
        }

        //DELETE /api/items/1
        [HttpDelete]
        public void DeleteCustomer (int id)
        {
            var itemInDb = _context.Items.SingleOrDefault(i => i.Id == id);

            if (itemInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Items.Remove(itemInDb);
            _context.SaveChanges();
        }
    }
}
