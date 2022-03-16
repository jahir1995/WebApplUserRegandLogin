using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApplUserRegandLogin.Models
{
    public class UserModel
    {
        [Required]

        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required.")]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required.")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID is Required.")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Password should be in minimum 8 characters atleast 1 Uppercase, 1 Lowercase, 1 Number and 1 Special Character.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is Required.")]
        [Display(Name = "Confirm Password: ")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Both Password's should be same")]
        public string ConfirmPassword { get; set; }

        public string SuccessMessage { get; set; }
    }
}