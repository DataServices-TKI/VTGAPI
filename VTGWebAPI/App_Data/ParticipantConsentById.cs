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
    
    public partial class ParticipantConsentById
    {
        public int PersonId { get; set; }
        public Nullable<int> StudyId { get; set; }
        public Nullable<int> SubjectStudyInformedConsentLinkId { get; set; }
        public Nullable<int> SubjectStudyLinkId { get; set; }
        public Nullable<int> InformedConsentId { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> VerbalConsentDate { get; set; }
        public Nullable<int> VerbalConsentBy { get; set; }
        public Nullable<System.DateTime> WrittenConsentDate { get; set; }
        public Nullable<int> WrittenConsentBy { get; set; }
        public string Name { get; set; }
    }
}
