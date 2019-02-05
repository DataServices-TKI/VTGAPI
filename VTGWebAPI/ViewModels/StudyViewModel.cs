using System;


namespace VTGWebAPI.ViewModels
{
    public class StudyViewModel
    {

        public int StudyId { get; set; }
        public string NameStudy { get; set; }
        public string NicknameStudy { get; set; }
        public string StudyType { get; set; }
        public int? StudyCoordinator { get; set; }
        public int? ExpNumSubjects { get; set; }
        public DateTime? RecruitmentStartDate { get; set; }
        public DateTime? RecruitmentEndDate { get; set; }
        public DateTime? FirstVisitStartDate { get; set; }
        public DateTime? FirstVisitEndDate { get; set; }
        public float? SubjectMinAgeInYears { get; set; }
        public string SubjectMinAgeInequality { get; set; }
        public float? SubjectMaxAgeInYears { get; set; }
        public string SubjectMaxAgeInequality { get; set; }
        public string BackgroundInfo { get; set; }
        public int? IsCompletedYN { get; set; }
        public DateTime? LastVisitEndDate { get; set; }
        public DateTime? OfficialStartDate { get; set; }
        public DateTime? OfficialEndDate { get; set; }
        public string GpMailoutStudyTitle { get; set; }
        public string GpMailoutStudyInfo { get; set; }
        public string GpMailoutStudyObjectives { get; set; }
        public int? StudyIsCurrentlyBlindedYN { get; set; }
        public int? IsSponsoredYN { get; set; }
    }
}