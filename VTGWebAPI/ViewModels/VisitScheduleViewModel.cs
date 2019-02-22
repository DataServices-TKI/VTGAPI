using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VTGWebAPI.App_Data;

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
        public int Vaccine { get; set; }
        public int Samples { get; set; }
        public int Travel { get; set; }
        public int Questionnaire { get; set; }

        public IEnumerable<VaccinationsByVisitViewModel> VaccineList { get; set; }
        public IEnumerable<SamplesByVisitViewModel> SampleList { get; set; }
        public IEnumerable<TravelReimbursementsByVisitViewModel> TravelList { get; set; }
        public IEnumerable<QuestionnaireByVisitViewModel> QuestionList { get; set; }




    }
}