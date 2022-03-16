using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplUserRegandLogin.Models;
using WebApplUserRegandLogin.ViewModel;

namespace WebApplUserRegandLogin.Controllers
{
    public class AccountController : Controller
    {
        CodingTestEntities1 objCodingTestEntities1 = new CodingTestEntities1();
        // GET: Account

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            UserModel objusermodel = new UserModel();
            return View(objusermodel);
        }

        [HttpPost]
        public ActionResult Register(UserModel objusermodel)
        {
            if (ModelState.IsValid)
            {
                Regandlog objRegandlog = new Regandlog();
                objRegandlog.FirstName = objusermodel.FirstName;
                objRegandlog.LastName = objusermodel.LastName;
                objRegandlog.Email = objusermodel.Email;
                objRegandlog.Password = objusermodel.Password;
                using (CodingTestEntities1 objCodingTestEntities1 = new CodingTestEntities1())
                {
                    if(objCodingTestEntities1.Regandlogs.Any(m =>m.Email.Contains(objusermodel.Email)))
                    {
                        ViewBag.DuplicateMessage = "Email is alredy Exist, add unique Email";
                        return View();
                    }
                    objCodingTestEntities1.Regandlogs.Add(objRegandlog);
                    objCodingTestEntities1.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Registeration is Successfully done..!";
                return View();                
            }            
            return View();
            
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginModel objLoginModel = new LoginModel();
            return View(objLoginModel);
        }

        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if(ModelState.IsValid)
            {
                if (objCodingTestEntities1.Regandlogs.Where(m => m.Email == objLoginModel.Email && m.Password == objLoginModel.Password).FirstOrDefault() != null)
                {  
                    Session["Email"] = objLoginModel.Email;
                    return RedirectToAction("AddImage", "Image");
                }
                else
                {

                    TempData["Alert Message"] = "Invalid Email or Password..!";                    
                    //Session["Email"] = objLoginModel.Email;
                    //return RedirectToAction("AddImage","Image");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}