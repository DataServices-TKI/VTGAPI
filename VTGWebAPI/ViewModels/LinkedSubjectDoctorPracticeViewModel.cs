using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class LinkedSubjectDoctorPracticeViewModel
    {
        public int SubjectDoctorPracticeLinkId { get; set; }
        public int DoctorPracticeLinkId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorType { get; set; }
        public string Practice { get; set; }
        public int PracticeId { get; set; }
        public int PersonId { get; set; }
        public short? Priority { get; set; }
        public int? ConsentToContactDr { get; set; }
        public string ConsentToContact { get; set; }
        public string Comments { get; set; }

    }
}