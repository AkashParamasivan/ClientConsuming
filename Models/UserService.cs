using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientConsuming.Models
{
    public class UserService
    {
        public string Usid { get; set; }
        [Required]
        [Remote("IsUserNameExist", "UserService",
                ErrorMessage = "Username name already exists")]
        public string Username { get; set; }
        [Required]
        [RegularExpression("^[6-9]{1}[0-9]{9}$", ErrorMessage = "Invalid mobile number")]
        public string Phoneno { get; set; }
      
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string Specialization { get; set; }
        public string Specification { get; set; }
        public string ServiceCity { get; set; }
        public string Address { get; set; }
        [Required]
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "Invalid Aadhaar number")]
        [Remote("IsUserAadhaarExist", "UserService",
                ErrorMessage = "Aadhaar number already exists")]
        public string Aadhaarno { get; set; }
        public string Role { get; set; }
        public int? Experience { get; set; }
        public int? Costperhour { get; set; }
        public int? Rating { get; set; }
    }
}
