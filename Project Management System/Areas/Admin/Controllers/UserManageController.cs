using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Management_System.Areas.Admin.Models;

namespace Project_Management_System.Areas.Admin.Controllers
{
    public class UserManageController : Controller
    {
        private PMSEntities1 db = new PMSEntities1();

        // GET: Admin/UserManage
        public ActionResult Index()
        {
            var tbl_ManageUsers = db.tbl_ManageUsers.Include(t => t.tbl_Designation);
            return View(tbl_ManageUsers.ToList());
        }

        // GET: Admin/UserManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ManageUsers tbl_ManageUsers = db.tbl_ManageUsers.Find(id);
            if (tbl_ManageUsers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ManageUsers);
        }

        // GET: Admin/UserManage/Create
        public ActionResult Create()
        {
            ViewBag.FKdesignationid = new SelectList(db.tbl_Designation, "id", "departmentname");
            return View();
        }

        // POST: Admin/UserManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userid,username,password,role,emailid,activitystatus,createdby,createddate,modifiedby,modifieddate,FKdesignationid")] tbl_ManageUsers tbl_ManageUsers)
        {
            if (ModelState.IsValid)
            {
                var mail = Convert.ToString(Session["useremail"]);
                tbl_ManageUsers.createdby = mail;
                tbl_ManageUsers.createddate = DateTime.Now;
                db.tbl_ManageUsers.Add(tbl_ManageUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FKdesignationid = new SelectList(db.tbl_Designation, "id", "departmentname", tbl_ManageUsers.FKdesignationid);
            return View(tbl_ManageUsers);
        }

        // GET: Admin/UserManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ManageUsers tbl_ManageUsers = db.tbl_ManageUsers.Find(id);
            if (tbl_ManageUsers == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKdesignationid = new SelectList(db.tbl_Designation, "id", "departmentname", tbl_ManageUsers.FKdesignationid);
            return View(tbl_ManageUsers);
        }

        // POST: Admin/UserManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userid,username,password,role,designation,emailid,activitystatus,createdby,createddate,modifiedby,modifieddate,FKdesignationid")] tbl_ManageUsers tbl_ManageUsers)
        {
            if (ModelState.IsValid)
            {
                var mail = Convert.ToString(Session["useremail"]);
                tbl_ManageUsers.createdby = mail;
                tbl_ManageUsers.createddate = DateTime.Now;

                db.Entry(tbl_ManageUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FKdesignationid = new SelectList(db.tbl_Designation, "id", "departmentname", tbl_ManageUsers.FKdesignationid);
            return View(tbl_ManageUsers);
        }

        // GET: Admin/UserManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ManageUsers tbl_ManageUsers = db.tbl_ManageUsers.Find(id);
            if (tbl_ManageUsers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ManageUsers);
        }

        // POST: Admin/UserManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ManageUsers tbl_ManageUsers = db.tbl_ManageUsers.Find(id);
            db.tbl_ManageUsers.Remove(tbl_ManageUsers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
