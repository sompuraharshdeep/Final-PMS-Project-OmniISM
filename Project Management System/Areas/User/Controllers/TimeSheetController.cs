using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Management_System.Areas.Admin.Models;

namespace Project_Management_System.Areas.User.Controllers
{
    public class TimeSheetController : Controller
    {
        private PMSEntities1 db = new PMSEntities1();

        // GET: User/TimeSheet
        public ActionResult Index()
        {
            var tbl_TimeSheet = db.tbl_TimeSheet.Include(t => t.tbl_ManageProjects).Include(t => t.tbl_ManageTask);
            return View(tbl_TimeSheet.ToList());
        }

        // GET: User/TimeSheet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TimeSheet tbl_TimeSheet = db.tbl_TimeSheet.Find(id);
            if (tbl_TimeSheet == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TimeSheet);
        }

        // GET: User/TimeSheet/Create
        public ActionResult Create()
        {
            ViewBag.FKprojectid = new SelectList(db.tbl_ManageProjects, "projectid", "projectname");
            ViewBag.FKtaskid = new SelectList(db.tbl_ManageTask, "taskid", "taskname");
            ViewBag.FKuserid = new SelectList(db.tbl_ManageUsers, "userid", "username");
            return View();
        }

        // POST: User/TimeSheet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FKprojectid,FKtaskid,FKuserid,startdate,enddate,actualhours,comments,createdby,createddate,modifiedby,modifieddate")] tbl_TimeSheet tbl_TimeSheet)
        {
            if (ModelState.IsValid)
            {
                var mail = Convert.ToString(Session["useremail"]);
                tbl_TimeSheet.createdby = mail;
                tbl_TimeSheet.createddate = DateTime.Now;

                db.tbl_TimeSheet.Add(tbl_TimeSheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKprojectid = new SelectList(db.tbl_ManageProjects, "projectid", "projectname", tbl_TimeSheet.FKprojectid);
            ViewBag.FKtaskid = new SelectList(db.tbl_ManageTask, "taskid", "taskname", tbl_TimeSheet.FKtaskid);
            ViewBag.FKuserid = new SelectList(db.tbl_ManageUsers, "userid", "username");
            return View(tbl_TimeSheet);
        }

        // GET: User/TimeSheet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TimeSheet tbl_TimeSheet = db.tbl_TimeSheet.Find(id);
            if (tbl_TimeSheet == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKprojectid = new SelectList(db.tbl_ManageProjects, "projectid", "projectname", tbl_TimeSheet.FKprojectid);
            ViewBag.FKtaskid = new SelectList(db.tbl_ManageTask, "taskid", "taskname", tbl_TimeSheet.FKtaskid);
            ViewBag.FKuserid = new SelectList(db.tbl_ManageUsers, "userid", "username");
            return View(tbl_TimeSheet);
        }

        // POST: User/TimeSheet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FKprojectid,FKtaskid,FKuserid,startdate,enddate,actualhours,comments,createdby,createddate,modifiedby,modifieddate")] tbl_TimeSheet tbl_TimeSheet)
        {
            if (ModelState.IsValid)
            {
                var mail = Convert.ToString(Session["useremail"]);
                tbl_TimeSheet.createdby = mail;
                tbl_TimeSheet.createddate = DateTime.Now;

                db.Entry(tbl_TimeSheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FKprojectid = new SelectList(db.tbl_ManageProjects, "projectid", "projectname", tbl_TimeSheet.FKprojectid);
            ViewBag.FKtaskid = new SelectList(db.tbl_ManageTask, "taskid", "taskname", tbl_TimeSheet.FKtaskid);
            ViewBag.FKuserid = new SelectList(db.tbl_ManageUsers, "userid", "username");
            return View(tbl_TimeSheet);
        }

        // GET: User/TimeSheet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TimeSheet tbl_TimeSheet = db.tbl_TimeSheet.Find(id);
            if (tbl_TimeSheet == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TimeSheet);
        }

        // POST: User/TimeSheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_TimeSheet tbl_TimeSheet = db.tbl_TimeSheet.Find(id);
            db.tbl_TimeSheet.Remove(tbl_TimeSheet);
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
