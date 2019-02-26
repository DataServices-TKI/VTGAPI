using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class RecruitmentViewModel
    {
        public int RecruitmentId { get; set; }
        public int StudyId { get; set; }
        public string SubjectInitials { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string RecruitmentSource { get; set; }
        public bool? IsEligible { get; set; }
        public string ReasonIfNotEligible { get; set; }
        public bool? IsEnrolled { get; set; }
        public string StudyNumber { get; set; }
        public int? EnquiryNumber { get; set; }
    }
}