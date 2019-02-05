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
    
    public partial class Visit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visit()
        {
            this.AdverseEvents = new HashSet<AdverseEvent>();
            this.Questionnaires = new HashSet<Questionnaire>();
            this.Samples = new HashSet<Sample>();
            this.TravelReimbursements = new HashSet<TravelReimbursement>();
            this.Vaccinations = new HashSet<Vaccination>();
        }
    
        public int VisitId { get; set; }
        public int SubjectStudyLinkId { get; set; }
        public Nullable<int> VisitScheduleId { get; set; }
        public string Description { get; set; }
        public Nullable<int> VisitOrder { get; set; }
        public Nullable<System.DateTime> ScheduledDate { get; set; }
        public Nullable<System.DateTime> ScheduledTime { get; set; }
        public Nullable<int> ScheduledDateAcceptability { get; set; }
        public Nullable<System.DateTime> ActualDate { get; set; }
        public Nullable<System.DateTime> ActualTime { get; set; }
        public Nullable<int> ActualDateAcceptability { get; set; }
        public int VisitCompletedYN { get; set; }
        public Nullable<int> VisitOverseenBy { get; set; }
        public Nullable<System.DateTime> IdealDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdverseEvent> AdverseEvents { get; set; }
        public virtual LinkSubjectsStudy LinkSubjectsStudy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sample> Samples { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TravelReimbursement> TravelReimbursements { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vaccination> Vaccinations { get; set; }
        public virtual VisitSchedule VisitSchedule { get; set; }
    }
}
