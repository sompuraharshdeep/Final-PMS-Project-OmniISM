using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using Project_Management_System.Areas.Admin.Models;

namespace Project_Management_System.Areas.Admin.Controllers
{
    public class ReportControllerController : Controller
    {
        PMSEntities1 db = new PMSEntities1();
        // GET: Admin/ReportController
        public ActionResult Report(DateTime? startdate, DateTime? enddate)
        {
            //if (startdate != null && enddate != null)
            //{
            //    var model = db.tbl_ManageProjects.Where(x => x.startdate >= startdate && x.enddate <= enddate).ToList();


            //    return View(model);
            //}


            //return View(db.tbl_ManageProjects.ToList());

            using (PMSEntities1 db = new PMSEntities1())
            {
                List<tbl_TimeSheet> timesheet = db.tbl_TimeSheet.ToList();
                List<tbl_ManageTask> task = db.tbl_ManageTask.ToList();
                List<tbl_ManageProjects> project = db.tbl_ManageProjects.ToList();
                if (startdate != null && enddate != null)
                {
                    // var Record = db.tbl_ManageProjects.Where(x => x.startdate >= startdate && x.enddate <= enddate).ToList();
                    var Record = from e in timesheet
                                 join d in task on e.FKtaskid equals d.taskid into table1
                                 from d in table1.ToList()
                                 join i in project on e.FKprojectid equals i.projectid into table2
                                 from i in table2.ToList()
                                 where (i.startdate >= startdate && i.enddate <= enddate)
                                 //(x => x.startdate >= startdate && x.enddate <= enddate).ToList();
                                 select new Join
                                 {
                                     timesheet = e,
                                     task = d,
                                     project = i
                                 };

                    return View(Record);
                }
                var filterRecord = from e in timesheet
                                   join d in task on e.FKtaskid equals d.taskid into table1
                                   from d in table1.ToList()
                                   join i in project on e.FKprojectid equals i.projectid into table2
                                   from i in table2.ToList()
                                       //(x => x.startdate >= startdate && x.enddate <= enddate).ToList();
                                   select new Join
                                   {
                                       timesheet = e,
                                       task = d,
                                       project = i
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

    }
}