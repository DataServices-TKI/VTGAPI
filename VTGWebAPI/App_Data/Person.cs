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
    
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Correspondences = new HashSet<Correspondence>();
            this.LinkSubjectDoctorPractices = new HashSet<LinkSubjectDoctorPractice>();
            this.LinkSubjectMedications = new HashSet<LinkSubjectMedication>();
            this.LinkSubjectsStudies = new HashSet<LinkSubjectsStudy>();
            this.MedicalHistories = new HashSet<MedicalHistory>();
            this.People1 = new HashSet<Person>();
            this.People11 = new HashSet<Person>();
        }
    
        public int PersonId { get; set; }
        public Nullable<int> VtgNumber { get; set; }
        public string UMRN { get; set; }
        public Nullable<int> DbConsentYesNo { get; set; }
        public string DbConsentType { get; set; }
        public Nullable<System.DateTime> DbConsentDateLastConfirmed { get; set; }
        public Nullable<int> NewsletterConsentYesNo { get; set; }
        public Nullable<System.DateTime> NewsletterConsentDateLastConfirmed { get; set; }
        public Nullable<int> FutureVtgResearchConsentYesNo { get; set; }
        public Nullable<System.DateTime> FutureVtgResearchConsentDateLastConfirmed { get; set; }
        public Nullable<int> FutureThirdPartyResearchlConsentYesNo { get; set; }
        public Nullable<System.DateTime> FutureThirdPartyResearchConsentDateLastConfirmed { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string PreferredName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public string Ethnicity { get; set; }
        public string PhoneWork { get; set; }
        public string PhoneMobile { get; set; }
        public string Email { get; set; }
        public string PreferredContactWritten { get; set; }
        public Nullable<int> Nok1PersonId { get; set; }
        public string Nok1Relationship { get; set; }
        public Nullable<int> Nok2PersonId { get; set; }
        public string Nok2Relationship { get; set; }
        public Nullable<int> HouseholdId { get; set; }
        public string RecruitmentSource { get; set; }
        public string Comments { get; set; }
        public string PreferredContactVerbal { get; set; }
        public Nullable<int> IsNok1ForKids { get; set; }
        public Nullable<int> IsNok2ForKids { get; set; }
        public Nullable<int> AgeInYrs { get; set; }
        public string AgeInYrMo { get; set; }
        public Nullable<int> AddresseeId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Correspondence> Correspondences { get; set; }
        public virtual Household Household { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LinkSubjectDoctorPractice> LinkSubjectDoctorPractices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LinkSubjectMedication> LinkSubjectMedications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LinkSubjectsStudy> LinkSubjectsStudies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicalHistory> MedicalHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> People1 { get; set; }
        public virtual Person Person1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> People11 { get; set; }
        public virtual Person Person2 { get; set; }
    }
}