using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class LinkVtgStaffStudyViewModel
    {
        public int VtgStaffStudyLinkId { get; set; }
        public int VtgStaffId { get; set; }
        public string StaffMember { get; set; }
        public int StudyId { get; set; }
        public string DatabaseRole { get; set; }
        public string ConcatRoles { get; set; }
        public bool IsBlindedYN { get; set; }
        public DateTime? EffFrom { get; set; }
        public DateTime? EffTo { get; set; }
    }
}