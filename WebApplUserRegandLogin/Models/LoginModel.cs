using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApplUserRegandLogin.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Email is Required.")]
        [Display (Name = "Email: ")]
        public string Email { get; set;}

        [Required(ErrorMessage = "Password is Required.")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
 
        public string Password { get; set; }
    }
}