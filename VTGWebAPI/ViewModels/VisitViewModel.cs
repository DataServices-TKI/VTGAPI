using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class VisitViewModel
    {
        public int VisitId { get; set; }
        public int SubjectStudyLinkId { get; set; }
        public int? VisitScheduleId { get; set; }
        public string Description { get; set; }
        public int? VisitOrder { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public int? ScheduledDateAcceptability { get; set; }
        public DateTime? ActualDate { get; set; }
        public DateTime? ActualTime { get; set; }
        public int? ActualDateAcceptability { get; set; }
        public int VisitCompletedYN { get; set; }
        public int? VisitOverseenBy { get; set; }
        public DateTime? IdealDate { get; set; }

        public string Participatnt { get; set; }
        public int PersonId { get; set; }
        public int StudyID { get; set; }
        public DateTime VisitDate { get; set; }
        public int Status { get; set; }
        public DateTime? EarliestDate { get; set; }
        public DateTime? LatestDate { get; set; }

        public IEnumerable<VaccineViewModel> VaccineList { get; set; }
        public IEnumerable<SamplesViewModel> SamplesList { get; set; }
        public IEnumerable<QuestionViewModel> QuestionList { get; set; }
        public IEnumerable<TravelReimbursementViewModel> TravelReimbursementList { get; set; }

    }
}