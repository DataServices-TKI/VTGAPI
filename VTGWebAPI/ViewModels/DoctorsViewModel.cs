using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VTGWebAPI.App_Data;

namespace VTGWebAPI.ViewModels
{
    public class DoctorsViewModel
    {
        public int DoctorId { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string MiddleInitials { get; set; }
        public string TypeDoctor { get; set; }
        public string Comments { get; set; }
        public string Fullname { get; set; }
        public int linkedDocPatientId { get; set; }

        public IEnumerable<PracticesViewModel> PracticeList { get; set; }
    }
}