using GymApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GymApplication.Controllers
{
    public class WorkoutController : Controller
    {
        private ApplicationDbContext _context;
        public WorkoutController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Workout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Workouts()
        {
            var users = _context.Users.Include(u => u.Role)
                                      .Include(u => u.MembershipType)
                                      .Include(u => u.Workout)
                                      .Where(u => u.Role.RoleName == "Member").ToList();
            return View(users);
        }

        public ActionResult AddWorkout(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();
            else
                return View(user);
        }

        public ActionResult Save(User user)
        {
            var userInDb = _context.Users.Single(u => u.Id == user.Id);
            if (userInDb.Workout != null)
                _context.Workouts.Remove(userInDb.Workout);
            userInDb.Workout = user.Workout;
            _context.SaveChanges();

            return RedirectToAction("Workouts", "Workout");
        }

        public ActionResult ViewWorkout(int id)
        {
            var user = _context.Users.Include(u => u.Workout).SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();
            else
                return View(user);
        }
    }
}