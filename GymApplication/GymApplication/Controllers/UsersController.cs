using GymApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymApplication.ViewModels;
using System.Data.Entity;
using System.Net;

namespace GymApplication.Controllers
{


    public class UsersController : Controller
    {

        private ApplicationDbContext _context;
        public UsersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Users
        public ActionResult Index()
        {
            var user = _context.Users.Include(u => u.Role).Include(u => u.MembershipType).ToList();

            return View(user);
        }

        public ActionResult AddUser()
        {
            var Role = _context.Roles.ToList();
            var MembershipType = _context.MembershipTypes.ToList();

            var viewModel = new AddUserForm
            {
                Roles = Role,
                MembershipTypes = MembershipType
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new AddUserForm
                {
                    User = user,
                    Roles = _context.Roles.ToList(),
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("AddUser", viewModel);

            }
        }

        //GET: /Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        [HttpPost]
        public ActionResult Save(User user)
        {
            if(user.Id == 0)
            {
                if(user.Role.RoleName == "Member")
                {
                    Earning earning = new Earning
                    {
                        Name = "User Registration",
                        Profit = user.MembershipType.MembershipFees,
                        Datetime = DateTime.Now
                    };

                    _context.Earnings.Add(earning);
                }
                    
                _context.Users.Add(user);

            }

            else
            {
                var userInDb = _context.Users.Single(u => u.Id == user.Id);

                userInDb.FirstName = user.FirstName;
                userInDb.LastName = user.LastName;
                userInDb.ImagePath = user.ImagePath;
                userInDb.MembershipTypeId = user.MembershipTypeId;
                userInDb.PhoneNumber = user.PhoneNumber;
                userInDb.RegistrationDate = user.RegistrationDate;
                userInDb.EmailAddress = user.EmailAddress;
                userInDb.Address = user.Address;
                userInDb.EmergencyNumber = user.EmergencyNumber;
                userInDb.DateOfBirth = user.DateOfBirth;
                userInDb.RoleId = user.RoleId;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Users") ;
        }

        //test users (Code to delete)
        public List<User> GetUsers()
        {
            var Monthly = new MembershipType
            {
                Id = 1,
                MembershipName = "Monthly",
                MembershipFees = 50

            };

            var Quartely = new MembershipType
            {
                Id = 2,
                MembershipName = "Quarterly",
                MembershipFees = 130

            };            
            
            var Biannualy = new MembershipType
            {
                Id = 3,
                MembershipName = "Biannualy",
                MembershipFees = 240

            };
                        
            var Yearly = new MembershipType
            {
                Id = 4,
                MembershipName = "Yearly",
                MembershipFees = 460

            };

            var users = new List<User>
            {

                new User { Id = 1, FirstName = "Tia", LastName = "Assaad" , DateOfBirth = new DateTime(2000,08,24),RegistrationDate = new DateTime(2020,03,05), MembershipType = Monthly },
                new User { Id = 2, FirstName = "Tony", LastName = "Habib", DateOfBirth = new DateTime(1993,08,27), RegistrationDate = new DateTime(2020,03,05),MembershipType = Yearly },
                new User { Id = 3, FirstName = "Joseph", LastName = "Youssef", DateOfBirth = new DateTime(1994,09,03), RegistrationDate = new DateTime(2020,03,05),MembershipType = Biannualy },
                new User { Id = 4, FirstName = "Nicolas", LastName = "Salloum", DateOfBirth = new DateTime(1996,01,01), RegistrationDate = new DateTime(2020,03,05),MembershipType = Yearly },
                new User { Id = 5, FirstName = "Elias", LastName ="Turk", DateOfBirth = new DateTime(1997,05,20), RegistrationDate = new DateTime(2020,03,05),MembershipType = Quartely},
                new User { Id = 6, FirstName = "Anthony", LastName ="Ghanem", DateOfBirth = new DateTime(1992,08,06), RegistrationDate = new DateTime(2020,03,05),MembershipType = Quartely},
                new User { Id = 7, FirstName = "Stephanie", LastName = "Habib", DateOfBirth = new DateTime(1988,01,08), RegistrationDate = new DateTime(2020,03,06),MembershipType = Biannualy},
                new User { Id = 8, FirstName = "Elie", LastName = "Akiki", DateOfBirth = new DateTime(1993,03,09), RegistrationDate = new DateTime(2020,03,09),MembershipType = Yearly}

            };


            return users;
        }
    }
}