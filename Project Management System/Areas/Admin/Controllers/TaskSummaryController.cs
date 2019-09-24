using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Project_Management_System.Areas.Admin.Models;

namespace Project_Management_System.Areas.Admin.Controllers
{
    public class TaskSummaryController : Controller
    {
        PMSEntities1 db = new PMSEntities1();
        // GET: Admin/TaskSummary
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TaskReport(DateTime? startdate, DateTime? enddate)
        {
            //if (startdate != null && enddate != null)
            //{
            //    var model = db.tbl_ManageProjects.Where(x => x.startdate >= startdate && x.enddate <= enddate).ToList();


            //    return View(model);
            //}


            //return View(db.tbl_ManageProjects.ToList());

            using (PMSEntities1 db = new PMSEntities1())
            {
                List<tbl_ManageTask> task = db.tbl_ManageTask.ToList();
                if (startdate != null && enddate != null)
                {
                    // var Record = db.tbl_ManageProjects.Where(x => x.startdate >= startdate && x.enddate <= enddate).ToList();
                    var Record = from e in task
                                 where (e.startdate >= startdate && e.enddate <= enddate)
                                 //(x => x.startdate >= startdate && x.enddate <= enddate).ToList();
                                 select new TaskSummary
                                 { 
                                     task = e                         
                                  };

                    return View(Record);
                }
                var filterRecord = from e in task
                                       //(x => x.startdate >= startdate && x.enddate <= enddate).ToList();
                                   select new TaskSummary
                                   {                                      
                                       task = e
                                    };

                return View(filterRecord);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A2);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }
        public ActionResult ViewTasks(int id)
        {
            tbl_ManageProjects projects = new tbl_ManageProjects();
            //ViewBag.projectdetail = db.tbl_ManageProjects.Where(a => a.projectid == id);

            var taskdata = db.tbl_ManageTask.Where(a => a.FKprojectid == id);
            return View(taskdata);
        }
    }
}