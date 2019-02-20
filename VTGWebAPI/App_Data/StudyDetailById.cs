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
    
    public partial class StudyDetailById
    {
        public int StudyId { get; set; }
        public string NameStudy { get; set; }
        public string NicknameStudy { get; set; }
        public string StudyType { get; set; }
        public Nullable<int> StudyCoordinator { get; set; }
        public Nullable<short> ExpNumSubjects { get; set; }
        public Nullable<System.DateTime> RecruitmentStartDate { get; set; }
        public Nullable<System.DateTime> RecruitmentEndDate { get; set; }
        public Nullable<System.DateTime> FirstVisitStartDate { get; set; }
        public Nullable<System.DateTime> FirstVisitEndDate { get; set; }
        public Nullable<double> SubjectMinAgeInYears { get; set; }
        public string SubjectMinAgeInequality { get; set; }
        public Nullable<double> SubjectMaxAgeInYears { get; set; }
        public string SubjectMaxAgeInequality { get; set; }
        public string BackgroundInfo { get; set; }
        public Nullable<int> IsCompletedYN { get; set; }
        public Nullable<System.DateTime> LastVisitEndDate { get; set; }
        public Nullable<System.DateTime> OfficialStartDate { get; set; }
        public Nullable<System.DateTime> OfficialEndDate { get; set; }
        public string GpMailoutStudyTitle { get; set; }
        public string GpMailoutStudyInfo { get; set; }
        public string GpMailoutStudyObjectives { get; set; }
        public Nullable<int> StudyIsCurrentlyBlindedYN { get; set; }
        public Nullable<int> IsSponsoredYN { get; set; }
        public Nullable<int> ElligibleByPhone { get; set; }
        public Nullable<int> EnrolledRecruits { get; set; }
        public Nullable<int> LinkedDB { get; set; }
    }
}
