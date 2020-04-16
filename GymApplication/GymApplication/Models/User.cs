using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = "ProfileImage/";

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }


        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Emergency Number")]
        public string EmergencyNumber { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "User Type")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display (Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        public string Age
        {
            get
            {
                TimeSpan age = DateTime.Now.Subtract(DateOfBirth);
                return (Math.Floor((age.TotalDays)/365.5).ToString());
            }
        }

        public DateTime? EndOfMembership
        {
            get
            {
                if (MembershipType.Id == 1)
                    return RegistrationDate.AddMonths(1);
                else if (MembershipType.Id == 2)
                    return RegistrationDate.AddMonths(3);
                else if (MembershipType.Id == 3)
                    return RegistrationDate.AddMonths(6);
                else if (MembershipType.Id == 4)
                    return RegistrationDate.AddYears(1);
                else
                    return null;

            }
        }

    }
}