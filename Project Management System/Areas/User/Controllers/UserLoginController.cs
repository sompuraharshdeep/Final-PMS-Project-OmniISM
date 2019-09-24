using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Management_System.Areas.Admin.Models;
namespace Project_Management_System.Areas.User.Controllers
{
    public class UserLoginController : Controller
    {
        PMSEntities1 db = new PMSEntities1();
        // GET: User/UserLogin
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(tbl_ManageUsers data)
        {
            try
            {

                var Logindata = db.tbl_ManageUsers.SingleOrDefault(a => a.username == data.username && a.password == data.password);
                if (Logindata != null)
                {
                    Session["userId"] = Logindata.userid;
                    Session["useremail"] = Logindata.username;
                    TempData["msg"] = "Login Done!";

                    return RedirectToAction("Index", "Home");
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