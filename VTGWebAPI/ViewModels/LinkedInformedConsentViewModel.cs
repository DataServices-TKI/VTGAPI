using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class LinkedInformedConsentViewModel
    {


        public int PersonId { get; set; }
        public int? StudyId { get; set; }
        public int SubjectStudyInformedConsentLinkId { get; set; }
        public int SubjectStudyLinkId { get; set; }
        public int InformedConsentId { get; set; }
        public string Status { get; set; }
        public DateTime? VerbalConsentDate { get; set; }
        public int? VerbalConsentBy { get; set; }
        public string VerbalConsentByName { get; set; }
        public DateTime? WrittenConsentDate { get; set; }
        public string WrittenConsenByName { get; set; }
        public int? WrittenConsentBy { get; set; }
        public string Name { get; set; }


       
    }
}