using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class CorrespondanceViewModel
    {

        public int CorrespondenceId { get; set; }
        public int PersonId { get; set; }
        public int? StudyId { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string RecipientAddress { get; set; }
        public string Topic { get; set; }
        public string TypeCorrespondence { get; set; }
        public string Details { get; set; }
        public DateTime? DateOfCorrespondence { get; set; }
        public int? VtgStaffId { get; set; }
        public string VtgStaff { get; set; }
        public int? FollowupStaff1 { get; set; }
        public int? FollowupStaff2 { get; set; }
        public string FollowupStaff { get; set; }
        public int? FollowupStaffEmailSent { get; set; }

       
    }
}