//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HerbalifeScoreApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class HL_Web_Win_Task
    {
        public int WinTaskId { get; set; }
        public Nullable<int> WebTaskId { get; set; }
        public string ReportCode { get; set; }
        public string CountryCode { get; set; }
        public string WHCode { get; set; }
        public Nullable<int> VendorId { get; set; }
        public Nullable<int> ReportYear { get; set; }
        public Nullable<int> ReportMonth { get; set; }
        public Nullable<System.DateTime> PeriodFrom { get; set; }
        public Nullable<System.DateTime> PeriodTo { get; set; }
        public Nullable<int> AgreementId { get; set; }
        public string DataFrom { get; set; }
        public Nullable<bool> NoData { get; set; }
        public string Status { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string ChangeUser { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
    }
}
