using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VTGWebAPI.App_Data;

namespace VTGWebAPI.ViewModels
{
    public class VaccineViewModel
    {
        public int VaccinationId { get; set; }
        public int VisitId { get; set; }
        public int? TypeVaccinationId { get; set; }
        public Nullable<int> WasScheduledAtStudyLevelYN { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DateAdministered { get; set; }
        public Nullable<System.DateTime> TimeAdministered { get; set; }
        public Nullable<System.DateTime> TimeRemovedFromFridge { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string SideSiteRoute { get; set; }
        public Nullable<int> RegisteredNurseId { get; set; }
        public Nullable<int> VtgStaffIdPresent { get; set; }
        public string Comments { get; set; }
        public Nullable<double> AmountInMls { get; set; }
        public Nullable<int> IsComplete { get; set; }

        
    }
}