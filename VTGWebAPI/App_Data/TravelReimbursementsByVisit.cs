//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VTGWebAPI.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TravelReimbursementsByVisit
    {
        public int TravelReimbursementsByVisitId { get; set; }
        public int VisitScheduleId { get; set; }
        public Nullable<double> PaymentAmount { get; set; }
    
        public virtual VisitSchedule VisitSchedule { get; set; }
    }
}
