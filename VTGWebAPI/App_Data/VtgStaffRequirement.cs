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
    using System.Collections.Generic;
    
    public partial class VtgStaffRequirement
    {
        public int VtgStaffRequirementId { get; set; }
        public int VtgStaffId { get; set; }
        public int VtgStaffRequirementTypeId { get; set; }
        public Nullable<System.DateTime> EffFrom { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
    
        public virtual VtgStaff VtgStaff { get; set; }
        public virtual VtgStaffRequirementType VtgStaffRequirementType { get; set; }
    }
}
