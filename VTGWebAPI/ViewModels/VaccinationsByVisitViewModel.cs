using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class VaccinationsByVisitViewModel
    {
        public int VaccinationsByVisitId { get; set; }
        public int? TypeVaccinationId { get; set; }
        public string VaccineName { get; set; }
        public int VisitScheduleId { get; set; }
        public decimal? AmountInMls { get; set; }

    }
}