using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class PracticesViewModel
    {
        public int PracticeId { get; set; }
        public string NamePractice { get; set; }
        public string AddressStreet { get; set; }
        public string AddressSuburb { get; set; }
        public string AddressPostcode { get; set; }
        public string AddressState { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string Comments { get; set; }
        public int linkedDocPatientId { get; set; }

        public IEnumerable<DoctorsViewModel> DoctorsList { get; set; }


    }
}