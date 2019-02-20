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
    
    public partial class LinkDoctorPractice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LinkDoctorPractice()
        {
            this.LinkSubjectDoctorPractices = new HashSet<LinkSubjectDoctorPractice>();
        }
    
        public int DoctorPracticeLinkId { get; set; }
        public int DoctorId { get; set; }
        public int PracticeId { get; set; }
        public Nullable<System.DateTime> EffFrom { get; set; }
        public Nullable<System.DateTime> EffTo { get; set; }
        public string Comments { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        public virtual Practice Practice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LinkSubjectDoctorPractice> LinkSubjectDoctorPractices { get; set; }
    }
}