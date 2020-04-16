using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymApplication.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string MembershipName { get; set; } = string.Empty;
        public int MembershipFees { get; set; }
        
    }
}