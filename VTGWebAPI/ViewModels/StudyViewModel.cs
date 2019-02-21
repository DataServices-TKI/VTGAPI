using System;
using System.Collections.Generic;
using VTGWebAPI.App_Data;

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
        public double? SubjectMinAgeInYears { get; set; }        
        public string SubjectMinAgeInequality { get; set; }
        public bool GreaterThan { get; set; }
        public bool GreaterThanEquals { get; set; }
        public double? SubjectMaxAgeInYears { get; set; }
        public int MinYear { get; set; }
        public int MinMonth { get; set; }
        public string SubjectMaxAgeInequality { get; set; }
        public bool LessThan { get; set; }
        public bool LessThanEquals { get; set; }
        public int MaxYear { get; set; }
        public int MaxMonth { get; set; }
        public string BackgroundInfo { get; set; }
        public int? IsCompletedYN { get; set; }
        public DateTime? LastVisitEndDate { get; set; }
        public DateTime? OfficialStartDate { get; set; }
        public DateTime? OfficialEndDate { get; set; }
        public string GpMailoutStudyTitle { get; set; }
        public string GpMailoutStudyInfo { get; set; }
        public string GpMailoutStudyObjectives { get; set; }
        public bool StudyIsCurrentlyBlindedYN { get; set; }
        public int? IsSponsoredYN { get; set; }
        public int? ElligibleByPhone { get; set; } 
        public int? EnrolledRecruits { get; set; }
        public int? LinkedDb { get; set; }

        public IEnumerable<RecruitmentViewModel> RecruitmentList { get; set; }
        public IEnumerable<VisitSchedule> VisitList { get; set; }
        public IEnumerable<InformedConsentViewModel> InformedConsentList { get; set; }
        public IEnumerable<CorrespondanceViewModel> Correspondence { get; set; }        
        public IEnumerable<LinkVtgStaffStudyViewModel> LinkVtgStaffStudies { get; set; }

    }
}