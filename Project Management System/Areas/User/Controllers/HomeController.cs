using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Project_Management_System.Areas.Admin.Models;

namespace Project_Management_System.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        PMSEntities1 db = new PMSEntities1();

        public ActionResult Index()
        {
            return View();
        }
        // GET: User/Home
        public ActionResult ForgotPassword()
        {
            return View();
        }



        public ActionResult ShowById()
        {
            int id = Convert.ToInt32(Session["userid"]);
            var tbl_ManageTasks = db.tbl_ManageTask.Where(a => a.FKuserid == id);

            return View(tbl_ManageTasks.ToList());
        }



        [HttpPost]
        public ActionResult ForgotPassword(string useremail)
        {
            //Verify Email ID
            //Generate Reset password link 
            //Send Email 
            string message = "";
           // bool status = false;

            using (PMSEntities1 db = new PMSEntities1())
            {
                var account = db.tbl_SuperAdminLogin.Where(a => a.useremail == useremail).FirstOrDefault();
                if (account != null)
                {
                    //Send email for reset password
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(account.useremail, "ResetPassword");
                    account.ResetPassword = resetCode;
                    //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
                    //in our model class in part 1
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    message = "Reset password link has been sent to your email id.";
                }
                else
                {
                    message = "Account not found";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult ResetPassword(string id)
        {
            //Verify the reset password link
            //Find account associated with this link
            //redirect to reset password page
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }

            using (PMSEntities1 db = new PMSEntities1())
            {
                var user = db.tbl_SuperAdminLogin.Where(a => a.ResetPassword == id).FirstOrDefault();
                if (user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.NewPassword = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (PMSEntities1 db = new PMSEntities1())
                {
                    var user = db.tbl_SuperAdminLogin.Where(a => a.ResetPassword == model.NewPassword).FirstOrDefault();
                    if (user != null)
                    {
                        user.password = Crypto.Hash(model.NewPassword);
                        user.ResetPassword = "";
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();
                        message = "New password updated successfully";
                    }
                }
            }
            else
            {
                message = "Something invalid";
            }
            ViewBag.Message = message;
            return View(model);
        }

        [NonAction]
        public void SendVerificationLinkEmail(string useremail,string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/User/" + emailFor;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("gujaratidhamal5@gmail.com");
            var toEmail = new MailAddress(useremail);
            var fromEmailPassword = "Harsh1998"; // Replace with actual password

            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";
                body = "<br/><br/>We are excited to tell you that your account is" +
                    " successfully created. Please click on the below link to verify your account" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/>br/>We got request for reset your account password. Please click on the below link to reset your password" +
                    "<br/><br/><a href=" + link + ">Reset Password link</a>";
            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
    }
}