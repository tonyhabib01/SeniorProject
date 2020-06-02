using GymApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GymApplication.Controllers
{
    public class DietController : Controller
    {
        private ApplicationDbContext _context;
        public DietController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Diet
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Diets()
        {
            var users = _context.Users.Include(u => u.Role).Include(u => u.MembershipType).Include(u=>u.DietPlan).Where(u=>u.Role.RoleName == "Member").ToList();
            return View(users);
        }

        public ActionResult AddDiet(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();

            else
                return View(user);
        }

        public ActionResult Save(User user)
        {
            var userInDb = _context.Users.Single(u=>u.Id == user.Id);
            if (userInDb.DietPlan != null)
                _context.DietPlans.Remove(userInDb.DietPlan);
            userInDb.DietPlan = user.DietPlan;
            _context.SaveChanges();

            return RedirectToAction("Diets","Diet");
        }

        public ActionResult ViewDiet(int id)
        {
            var user = _context.Users.Include(u => u.DietPlan).SingleOrDefault(u => u.Id == id);
            if (user == null)
                return HttpNotFound();
            else
                return View(user);
        }
    }
}