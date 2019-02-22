using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class SamplesByVisitViewModel
    {
        public int SamplesByVisitId { get; set; }
        public int? TypeSampleId { get; set; }
        public string SampleName { get; set; }
        public int VisitScheduleId { get; set; }
        public decimal? Quantity { get; set; }
        public string Units { get; set; }
    }
}