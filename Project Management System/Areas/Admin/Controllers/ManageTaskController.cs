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
    public class ManageTaskController : Controller
    {
        private PMSEntities1 db = new PMSEntities1();

        // GET: Admin/ManageTask
        public ActionResult Index()
        {
            var tbl_ManageTask = db.tbl_ManageTask.Include(t => t.tbl_Designation).Include(t => t.tbl_ManageProjects);
            return View(tbl_ManageTask.ToList());
        }

        // GET: Admin/ManageTask/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ManageTask tbl_ManageTask = db.tbl_ManageTask.Find(id);
            if (tbl_ManageTask == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ManageTask);
        }

        // GET: Admin/ManageTask/Create
        public ActionResult Create()
        {
            ViewBag.FKuserid = new SelectList(db.tbl_ManageUsers, "userid", "username");
            ViewBag.FKdesignationid = new SelectList(db.tbl_Designation, "id", "departmentname");
            ViewBag.FKprojectid = new SelectList(db.tbl_ManageProjects, "projectid", "projectname");
            return View();
        }

        // POST: Admin/ManageTask/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "taskid,taskname,description,startdate,enddate,estimatedhours,taskstatus,createdby,createddate,modifiedby,modifieddate,allocatedto,FKuserid,FKprojectid,FKdesignationid,TaskCount")] tbl_ManageTask tbl_ManageTask)
        {
            if (ModelState.IsValid)
            {
                var createdby = Convert.ToString(Session["useremail"]);
                tbl_ManageTask.createdby = createdby;
                tbl_ManageTask.createddate = DateTime.Now;

                db.tbl_ManageTask.Add(tbl_ManageTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKuserid = new SelectList(db.tbl_ManageUsers, "userid", "username", tbl_ManageTask.FKuserid);
            ViewBag.FKdesignationid = new SelectList(db.tbl_Designation, "id", "departmentname", tbl_ManageTask.FKdesignationid);
            ViewBag.FKprojectid = new SelectList(db.tbl_ManageProjects, "projectid", "projectname", tbl_ManageTask.FKprojectid);
            return View(tbl_ManageTask);
        }

        // GET: Admin/ManageTask/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ManageTask tbl_ManageTask = db.tbl_ManageTask.Find(id);
            if (tbl_ManageTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKuserid = new SelectList(db.tbl_ManageUsers, "userid", "username", tbl_ManageTask.FKuserid);
            ViewBag.FKdesignationid = new SelectList(db.tbl_Designation, "id", "departmentname", tbl_ManageTask.FKdesignationid);
            ViewBag.FKprojectid = new SelectList(db.tbl_ManageProjects, "projectid", "projectname", tbl_ManageTask.FKprojectid);
            return View(tbl_ManageTask);
        }

        // POST: Admin/ManageTask/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "taskid,taskname,description,startdate,enddate,estimatedhours,taskstatus,createdby,createddate,modifiedby,modifieddate,allocatedto,FKuserid,FKprojectid,FKdesignationid,TaskCount")] tbl_ManageTask tbl_ManageTask)
        {
            if (ModelState.IsValid)
            {
                var createdby = Convert.ToString(Session["useremail"]);
                tbl_ManageTask.createdby = createdby;
                tbl_ManageTask.createddate = DateTime.Now;

                db.Entry(tbl_ManageTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKuserid = new SelectList(db.tbl_ManageUsers, "userid", "username", tbl_ManageTask.FKuserid);
            ViewBag.FKdesignationid = new SelectList(db.tbl_Designation, "id", "departmentname", tbl_ManageTask.FKdesignationid);
            ViewBag.FKprojectid = new SelectList(db.tbl_ManageProjects, "projectid", "projectname", tbl_ManageTask.FKprojectid);
            return View(tbl_ManageTask);
        }

        // GET: Admin/ManageTask/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ManageTask tbl_ManageTask = db.tbl_ManageTask.Find(id);
            if (tbl_ManageTask == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ManageTask);
        }

        // POST: Admin/ManageTask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ManageTask tbl_ManageTask = db.tbl_ManageTask.Find(id);
            db.tbl_ManageTask.Remove(tbl_ManageTask);
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
