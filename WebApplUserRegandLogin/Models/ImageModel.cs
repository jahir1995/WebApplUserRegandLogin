using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplUserRegandLogin.Models
{
    public class ImageModel
    {
        [Required]
        public int ImageID { get; set; }

        public string ImageName { get; set; }
        [Display(Name = "Upload Image")]

        public string ImagePath { get; set; }
        

        public HttpPostedFileBase ImageFile { get; set; }
    }
}