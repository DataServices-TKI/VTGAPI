using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class MedicalHistoryViewModel
    {

        public int MedicalHistoryId { get; set; }
        public int PersonId { get; set; }
        public int DiagnosisId { get; set; }
        public int BodySystemId { get; set; }
        public string Status { get; set; }
        public string YearDiagnosed { get; set; }
        public int? AgeDiagnosed { get; set; }
        public string Comments { get; set; }

        
    }
}