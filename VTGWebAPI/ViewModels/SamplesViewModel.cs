using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class SamplesViewModel
    {
        public int SampleId { get; set; }
        public int VisitId { get; set; }
        public Nullable<int> TypeSampleId { get; set; }
        public Nullable<int> WasScheduledAtStudyLevelYN { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CollectionDate { get; set; }
        public Nullable<System.DateTime> CollectionTime { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string Units { get; set; }
        public Nullable<int> RegisteredNurseId { get; set; }
        public Nullable<int> VtgStaffIdPresent { get; set; }
        public string Comments { get; set; }
        public Nullable<int> IsComplete { get; set; }
    }
}