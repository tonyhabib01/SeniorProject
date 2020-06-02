using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymApplication.Controllers
{
    public class MembershipPlansController : Controller
    {
        // GET: MembershipPlans
        public ActionResult Index()
        {
            return View();
        }
    }
}