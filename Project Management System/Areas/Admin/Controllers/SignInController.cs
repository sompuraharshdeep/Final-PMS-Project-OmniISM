using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Management_System.Areas.Admin.Models;

namespace Project_Management_System.Areas.Admin.Controllers
{
    public class SignInController : Controller
    {
        PMSEntities1 db = new PMSEntities1();
        // GET: Admin/SignIn
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tbl_SuperAdminLogin data)
        {
            try
            {

                var Logindata = db.tbl_SuperAdminLogin.SingleOrDefault(a => a.useremail == data.useremail && a.password == data.password);
                if (Logindata != null)
                {
                    Session["adminId"] = Logindata.id;
                    Session["useremail"] = Logindata.useremail;
                    TempData["msg"] = "Login Done!";

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["err"] = "Username or Password is Wrong!!";

                }
            }
            catch (Exception ex)
            {
                TempData["err"] = ex.Message;
            }
            return View();
        }
    }
}