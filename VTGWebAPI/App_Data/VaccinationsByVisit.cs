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
    
    public partial class VaccinationsByVisit
    {
        public int VaccinationsByVisitId { get; set; }
        public Nullable<int> TypeVaccinationId { get; set; }
        public int VisitScheduleId { get; set; }
        public Nullable<double> AmountInMls { get; set; }
    
        public virtual VaccinationType VaccinationType { get; set; }
        public virtual VisitSchedule VisitSchedule { get; set; }
    }
}
