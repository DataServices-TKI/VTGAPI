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

        public string Participatnt { get; set;}
        public string StudyID { get; set; }
        public int Status { get; set; }
        public DateTime Visit1 { get; set; }
        public DateTime Visit2 { get; set; }
        public DateTime Visit3 { get; set; }
        public DateTime Visit4 { get; set; }
        public DateTime Visit5 { get; set; }
        public DateTime Visit6 { get; set; }    
    }
}