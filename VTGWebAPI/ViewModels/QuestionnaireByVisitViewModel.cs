using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class QuestionnaireByVisitViewModel
    {
        public int QuestionnairesByVisitId { get; set; }
        public int? TypeQuestionnaireId { get; set; }
        public string QuestionnaireTypeName{ get; set; }
        public int VisitScheduleId { get; set; }
    }
}