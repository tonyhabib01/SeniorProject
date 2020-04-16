using GymApplication.Models;
using GymApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GymApplication.Controllers
{
    public class ClassesController : Controller
    {

        private ApplicationDbContext _context;
        public ClassesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Classes
        public ActionResult Index()
        {
            var classes = _context.Classes.ToList();
            
            return View(classes);
        }

        public ActionResult ManageClass()
        {
            var classes = _context.Classes.ToList();

            return View(classes);
        }
        
        public ActionResult AddClass()
        {
            ViewBag.TitleName = "Add Class";
            var days = new AddClassForm();
            return View(days);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class Class = _context.Classes.Find(id);
            if (Class == null)
            {
                return HttpNotFound();
            }
            return View(Class);
        }

        // POST: /Classes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var Class = _context.Classes.Find(id);
            _context.Classes.Remove(Class);
            _context.SaveChanges();

            return RedirectToAction("Index", "Classes");
        }



        [HttpPost]
        public ActionResult Save(AddClassForm classes)
        {

            if (classes.Class.Id == 0)
            {
                _context.Classes.Add(classes.Class);

            }

            else
            {
                var classInDb = _context.Classes.Single(c => c.Id == classes.Class.Id);

                classInDb.Name = classes.Class.Name;
                classInDb.Day = classes.Class.Day;
                classInDb.StartTime = classes.Class.StartTime;
                 
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Classes");
        }

        public ActionResult EditClass(int id)
        {
            ViewBag.TitleName = "Edit Class";
            var Class = _context.Classes.SingleOrDefault(c => c.Id == id);

            if (Class == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new AddClassForm {
                
                    Class = Class
                };


                return View("AddClass", viewModel);

            }
        }



        //public IEnumerable<Class> GetClass()
        //{
        //    var classes = new List<Class>
        //    {
        //        new Class {Id = 1, Name = "Fitness", ClassTimes = new List<ClassTime>{ new ClassTime {Day = "Monday", StartTime = "00:00", EndTime = "01:00" } } },
        //        new Class {Id = 2, Name = "MMA", ClassTimes = new List<ClassTime>{ new ClassTime {Day = "Tuesday", StartTime = "12:00", EndTime = "13:00" } } },
        //        new Class {Id = 3, Name = "6-Packs", ClassTimes = new List<ClassTime>{ new ClassTime {Day = "Friday", StartTime = "05:00", EndTime = "06:00" } } },
        //        new Class {Id = 4, Name = "Yoga", ClassTimes = new List<ClassTime>{ new ClassTime {Day = "Tuesday", StartTime = "16:00", EndTime = "17:00" } } },
        //        new Class {Id = 5, Name = "Parkour", ClassTimes = new List<ClassTime>{ new ClassTime {Day = "Tuesday", StartTime = "00:00", EndTime = "01:00" } } }
        //    };
        //    return classes;
        //}
        public IEnumerable<Class> GetClasses()
        {
            var classes = new List<Class>
            {
                new Class {Id = 1 ,Name ="Fitness", Day = "Monday", StartTime = "00:00" , EndTime = "01:00" },
                new Class {Id = 2 ,Name ="Workout", Day = "Tuesday", StartTime = "12:00" , EndTime = "13:00" },
                new Class {Id = 3 ,Name ="Gym", Day = "Friday", StartTime = "05:00" , EndTime = "06:00" },
                new Class {Id = 4 ,Name ="Gymmmm", Day = "Tuesday", StartTime = "16:00" , EndTime = "17:00" },
                new Class {Id = 5 ,Name ="Parkour", Day = "Wednesday", StartTime = "00:00" , EndTime = "01:00" },
                new Class {Id = 6 ,Name ="Workout", Day = "Thursday", StartTime = "00:00" , EndTime = "01:00" },
                new Class {Id = 7 ,Name ="Gym1", Day = "Friday", StartTime = "00:00" , EndTime = "01:00" },
                new Class {Id = 8 ,Name ="Cardio", Day = "Saturday", StartTime = "00:00" , EndTime = "01:00" },
                new Class {Id = 9 ,Name ="High Intensity", Day = "Tuesday", StartTime = "00:00" , EndTime = "01:00" }
            };
            return classes;
        }


    }
}