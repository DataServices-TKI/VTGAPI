using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class VisitScheduleViewModel
    {

        public int VisitScheduleId { get; set; }
        public int StudyId { get; set; }
        public int VisitOrder { get; set; }
        public string Description { get; set; }
        public int? IdealDaysAfterPrevious { get; set; }
        public int? MinDaysAfterPrevious { get; set; }
        public int? MaxDaysAfterPrevious { get; set; }
        public int? VisitOrderThatTimingIsRelativeTo { get; set; }
        public string Comments { get; set; }
        public string VisitStream { get; set; }
    }
}