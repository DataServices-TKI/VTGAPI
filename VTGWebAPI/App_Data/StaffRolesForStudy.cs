//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VTGWebAPI.App_Data
{
    using System;
    
    public partial class StaffRolesForStudy
    {
        public int VtgStaffStudyLinkId { get; set; }
        public int VtgStaffId { get; set; }
        public int StudyId { get; set; }
        public string DatabaseRole { get; set; }
        public string ConcatRoles { get; set; }
        public Nullable<int> IsBlindedYN { get; set; }
        public Nullable<System.DateTime> EffFrom { get; set; }
        public Nullable<System.DateTime> EffTo { get; set; }
        public string StaffMember { get; set; }
    }
}