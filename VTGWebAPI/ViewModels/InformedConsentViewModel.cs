using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class InformedConsentViewModel
    {

        public int InformedConsentId { get; set; }
        public int StudyId { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public string OrgApprovedBy { get; set; }
        public int? ApprovedBy { get; set; }        
        public DateTime? ApprovedWhen { get; set; }
}
}