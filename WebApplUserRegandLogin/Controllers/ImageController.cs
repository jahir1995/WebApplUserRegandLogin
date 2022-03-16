using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplUserRegandLogin.ViewModel;

namespace WebApplUserRegandLogin.Controllers
{
    public class ImageController : Controller
    {
        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(TestImgDB imagemodel)
        {

            string fileName = Path.GetFileNameWithoutExtension(imagemodel.ImageFile.FileName);
            string extension = Path.GetExtension(imagemodel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imagemodel.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            imagemodel.ImageFile.SaveAs(fileName);
            using (CodingTestEntities1 db = new CodingTestEntities1())
            {
                if (db.TestImgDBs.Any(m => m.ImageName.Contains(imagemodel.ImageName)))
                {
                    ViewBag.DuplicateMessage = "File Name Already Exist, add unique file name";
                    return View();
                }
                db.TestImgDBs.Add(imagemodel);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SucessMessage = "Image Added Successfully in the Image Gallery..!";
            return View();

        }
        [HttpGet]
        public ActionResult ShowImage(int id)
        {
            TestImgDB imagemodel = new TestImgDB();
            using (CodingTestEntities1 db = new CodingTestEntities1())
            {
                imagemodel = db.TestImgDBs.Where(m => m.ImageID == id).FirstOrDefault();
            }
            return View(imagemodel);
        }

        [HttpGet]
        public ActionResult ShowAllImage()
        {
            List<TestImgDB> imagemodel = new List<TestImgDB>();
            using (CodingTestEntities1 db = new CodingTestEntities1())
            {
                imagemodel = db.TestImgDBs.Select(x => x).ToList();
            }
            return View(imagemodel);
        }
    }
}
