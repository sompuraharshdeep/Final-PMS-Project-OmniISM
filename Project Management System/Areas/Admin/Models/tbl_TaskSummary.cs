//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_Management_System.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_TaskSummary
    {
        public int id { get; set; }
        public Nullable<int> FKtimesheetid { get; set; }
    
        public virtual tbl_TimeSheet tbl_TimeSheet { get; set; }
    }
}