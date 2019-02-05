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
    
    public partial class VisitSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VisitSchedule()
        {
            this.QuestionnairesByVisits = new HashSet<QuestionnairesByVisit>();
            this.SamplesByVisits = new HashSet<SamplesByVisit>();
            this.TravelReimbursementsByVisits = new HashSet<TravelReimbursementsByVisit>();
            this.VaccinationsByVisits = new HashSet<VaccinationsByVisit>();
            this.Visits = new HashSet<Visit>();
        }
    
        public int VisitScheduleId { get; set; }
        public int StudyId { get; set; }
        public int VisitOrder { get; set; }
        public string Description { get; set; }
        public Nullable<short> IdealDaysAfterPrevious { get; set; }
        public Nullable<short> MinDaysAfterPrevious { get; set; }
        public Nullable<short> MaxDaysAfterPrevious { get; set; }
        public Nullable<int> VisitOrderThatTimingIsRelativeTo { get; set; }
        public string Comments { get; set; }
        public string VisitStream { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionnairesByVisit> QuestionnairesByVisits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SamplesByVisit> SamplesByVisits { get; set; }
        public virtual Study Study { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TravelReimbursementsByVisit> TravelReimbursementsByVisits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaccinationsByVisit> VaccinationsByVisits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
