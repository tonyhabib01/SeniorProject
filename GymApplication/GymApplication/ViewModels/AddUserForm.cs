using GymApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymApplication.ViewModels
{
    public class AddUserForm
    {
        public IEnumerable<Role> Roles { get; set; }
        public User User { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}