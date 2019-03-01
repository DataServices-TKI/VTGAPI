using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class TravelReimbursementViewModel
    {
        public int TravelReimbursementId { get; set; }
        public int VisitId { get; set; }
        public Nullable<int> WasScheduledAtStudyLevelYN { get; set; }
        public Nullable<int> ApprovedBy { get; set; }
        public string ApprovedByName { get; set; }
        public Nullable<System.DateTime> ApprovedWhen { get; set; }
        public Nullable<double> PaymentAmount { get; set; }
        public string PaymentType { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public Nullable<int> PaymentCheckedBy { get; set; }
        public string Comments { get; set; }
        public Nullable<int> IsComplete { get; set; }
        public string WhyNotCompleted { get; set; }
    }
}