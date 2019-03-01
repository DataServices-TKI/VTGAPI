using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionnaireId { get; set; }
        public int VisitId { get; set; }
        public string Description { get; set; }
        public Nullable<int> TypeQuestionnaireId { get; set; }
        public Nullable<int> WasScheduledAtStudyLevelYN { get; set; }
        public Nullable<System.DateTime> DateIssued { get; set; }
        public Nullable<int> IssuedBy { get; set; }
        public Nullable<System.DateTime> DateReceived { get; set; }
        public Nullable<int> ReceivedBy { get; set; }
        public Nullable<int> IsComplete { get; set; }
        public string Comments { get; set; }
    }
}