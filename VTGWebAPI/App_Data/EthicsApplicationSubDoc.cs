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
    
    public partial class EthicsApplicationSubDoc
    {
        public int EthicsApplicationSubDocId { get; set; }
        public int EthicsApplicationId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string OrgSentTo { get; set; }
        public Nullable<System.DateTime> DateDue { get; set; }
        public Nullable<System.DateTime> DateSubmitted { get; set; }
        public Nullable<System.DateTime> DateReceived { get; set; }
        public Nullable<System.DateTime> DateAcknowledged { get; set; }
        public Nullable<System.DateTime> DateApproved { get; set; }
    
        public virtual EthicsApplication EthicsApplication { get; set; }
    }
}
