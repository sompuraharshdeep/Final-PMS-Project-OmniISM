using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Management_System.Areas.Admin.Models
{
    public class Join
    {
        public tbl_ManageProjects project { get; set; }
        public tbl_ManageTask task { get; set; }
        public tbl_TimeSheet timesheet { get; set; }
    }
}