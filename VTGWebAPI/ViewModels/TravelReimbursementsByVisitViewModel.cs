using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class TravelReimbursementsByVisitViewModel
    {
        public int TravelReimbursementsByVisitId { get; set; }
        public int VisitScheduleId { get; set; }      
        public decimal? PaymentAmount { get; set;}
    }
}