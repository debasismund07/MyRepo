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
    
    public partial class HL_Web_Win_ReportData_KPIWH_Data
    {
        public int Id { get; set; }
        public Nullable<int> WinTaskId { get; set; }
        public Nullable<int> ItemDetailid { get; set; }
        public Nullable<decimal> ActualValue { get; set; }
        public Nullable<decimal> ContractValue { get; set; }
        public string Remark { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string ChangeUser { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
    }
}
