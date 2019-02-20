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
    
    public partial class AdverseEvent
    {
        public int AdverseEventId { get; set; }
        public int VisitId { get; set; }
        public Nullable<int> DiagnosisId { get; set; }
        public string TypeOfEvent { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> StopDate { get; set; }
        public Nullable<int> Ongoing { get; set; }
        public string Intensity { get; set; }
        public string Causality { get; set; }
        public Nullable<int> WasMedicalAdviceSought { get; set; }
        public string TypeOfMedicalAdvice { get; set; }
        public Nullable<System.DateTime> SaeNocdDateOfDiagnosis { get; set; }
        public Nullable<System.DateTime> SaeNocdDateReportedToVtg { get; set; }
        public Nullable<System.DateTime> SaeNocdDateReportedToSponsor { get; set; }
        public string SaeNocdSourceOfInfo { get; set; }
        public string SaeNocdMethodOfMgmt { get; set; }
        public string SaeNocdOutcome { get; set; }
        public string SaeNocdComments { get; set; }
        public Nullable<int> SaeNocdVtgStaffWitnessId { get; set; }
        public Nullable<System.DateTime> PregDateOfLmp { get; set; }
        public string PregMethodOfDiagnosis { get; set; }
        public Nullable<System.DateTime> PregExpectedDateOfDelivery { get; set; }
        public string PregRiskFactors { get; set; }
        public string PregOutcome { get; set; }
        public Nullable<System.DateTime> PregEndDate { get; set; }
        public string PregComments { get; set; }
    
        public virtual Visit Visit { get; set; }
        public virtual DiagnosesIcd DiagnosesIcd { get; set; }
    }
}