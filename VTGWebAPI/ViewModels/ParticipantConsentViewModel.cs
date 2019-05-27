using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class ParticipantConsentViewModel
    {
        public int RowId { get; set; }
        public Nullable<int> VtgNumber { get; set; }
        public Nullable<short> ProcessingStatusCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string PhoneDesk { get; set; }
        public string PhoneMobile { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<bool> NewsletterConsentYesNo { get; set; }
        public Nullable<bool> FutureVtgResearchConsentYesNo { get; set; }
        public Nullable<bool> DbConsentYesNo { get; set; }
        public Nullable<System.DateTime> DateConsented { get; set; }
        public string FamilyMemberFirstName1 { get; set; }
        public string FamilyMemberLastName1 { get; set; }
        public string FamilyMemberGender1 { get; set; }
        public Nullable<System.DateTime> FamilyMemberDOB1 { get; set; }
        public string FamilyMemberRelationship1 { get; set; }
        public string FamilyMemberFirstName2 { get; set; }
        public string FamilyMemberLastName2 { get; set; }
        public string FamilyMemberGender2 { get; set; }
        public Nullable<System.DateTime> FamilyMemberDOB2 { get; set; }
        public string FamilyMemberRelationship2 { get; set; }
        public string FamilyMemberFirstName3 { get; set; }
        public string FamilyMemberLastName3 { get; set; }
        public string FamilyMemberGender3 { get; set; }
        public Nullable<System.DateTime> FamilyMemberDOB3 { get; set; }
        public string FamilyMemberRelationship3 { get; set; }
        public string FamilyMemberFirstName4 { get; set; }
        public string FamilyMemberLastName4 { get; set; }
        public string FamilyMemberGender4 { get; set; }
        public Nullable<System.DateTime> FamilyMemberDOB4 { get; set; }
        public string FamilyMemberRelationship4 { get; set; }
        public string FamilyMemberFirstName5 { get; set; }
        public string FamilyMemberLastName5 { get; set; }
        public string FamilyMemberGender5 { get; set; }
        public Nullable<System.DateTime> FamilyMemberDOB5 { get; set; }
        public string FamilyMemberRelationship5 { get; set; }
        public string FamilyMemberFirstName6 { get; set; }
        public string FamilyMemberLastName6 { get; set; }
        public string FamilyMemberGender6 { get; set; }
        public Nullable<System.DateTime> FamilyMemberDOB6 { get; set; }
        public string FamilyMemberRelationship6 { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}