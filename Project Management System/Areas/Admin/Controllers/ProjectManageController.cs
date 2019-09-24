using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Management_System.Areas.Admin.Models;

namespace Project_Management_System.Areas.Admin.Controllers
{
    public class ProjectManageController : Controller
    {
        private PMSEntities1 db = new PMSEntities1();

        // GET: Admin/ProjectManage
        public ActionResult Index()
        {
            var createdby = Convert.ToString(Session["useremail"]);
            return View(db.tbl_ManageProjects.ToList());
        }

        // GET: Admin/ProjectManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ManageProjects tbl_ManageProjects = db.tbl_ManageProjects.Find(id);
            if (tbl_ManageProjects == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ManageProjects);
        }

        // GET: Admin/ProjectManage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProjectManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "projectid,projectname,description,startdate,enddate,documentupload,estimatedhours,actualhours,projectstatus,activitystatus,createdby,createddate,modifiedby,modifieddate")] tbl_ManageProjects tbl_ManageProjects, HttpPostedFileBase[] documentupload)
        {
            if (ModelState.IsValid)
            {
                var createdby = Convert.ToString(Session["useremail"]);
                tbl_ManageProjects.createdby = createdby;
                tbl_ManageProjects.createddate = DateTime.Now;

                string allfl = "";
                foreach (HttpPostedFileBase file in documentupload)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Content/Admin/UploadedFiles/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = documentupload.Count().ToString() + " files uploaded successfully.";
                        allfl += InputFileName + ",";
                    }
                }
                tbl_ManageProjects.documentupload = allfl.Remove(allfl.Length-1,1);
                db.tbl_ManageProjects.Add(tbl_ManageProjects);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(tbl_ManageProjects);
        }

        // GET: Admin/ProjectManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ManageProjects tbl_ManageProjects = db.tbl_ManageProjects.Find(id);
            if (tbl_ManageProjects == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ManageProjects);
        }

        // POST: Admin/ProjectManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "projectid,projectname,description,startdate,enddate,documentupload,estimatedhours,actualhours,projectstatus,activitystatus,createdby,createddate,modifiedby,modifieddate")] tbl_ManageProjects tbl_ManageProjects)
        {
            if (ModelState.IsValid)
            {
                var modifiedby = Convert.ToString(Session["useremail"]);
                tbl_ManageProjects.modifiedby = modifiedby;
                tbl_ManageProjects.modifieddate = DateTime.Now;

                db.Entry(tbl_ManageProjects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_ManageProjects);
        }

        // GET: Admin/ProjectManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ManageProjects tbl_ManageProjects = db.tbl_ManageProjects.Find(id);
            if (tbl_ManageProjects == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ManageProjects);
        }

        // POST: Admin/ProjectManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ManageProjects tbl_ManageProjects = db.tbl_ManageProjects.Find(id);
            db.tbl_ManageProjects.Remove(tbl_ManageProjects);
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
