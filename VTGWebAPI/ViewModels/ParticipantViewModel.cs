using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VTGWebAPI.App_Data;
using VTGWebAPI.ViewModels;

namespace VTGWebAPI.ViewModels
{
    public class ParticipantViewModel
    {
        public int PersonId { get; set; }
        public int? VtgNumber { get; set; }
        public string UMRN { get; set; }
        public int? DbConsentYesNo { get; set; }
        public string DbConsentType { get; set; }
        public DateTime? DbConsentDateLastConfirmed { get; set; }
        public int? NewsletterConsentYesNo { get; set; }
        public DateTime? NewsletterConsentDateLastConfirmed { get; set; }
        public int? FutureVtgResearchConsentYesNo { get; set; }
        public DateTime? FutureVtgResearchConsentDateLastConfirmed { get; set; }
        public int? FutureThirdPartyResearchlConsentYesNo { get; set; }
        public DateTime? FutureThirdPartyResearchConsentDateLastConfirmed { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string PreferredName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Ethnicity { get; set; }
        public string PhoneWork { get; set; }
        public string PhoneMobile { get; set; }
        public string Email { get; set; }
        public string PreferredContactWritten { get; set; }
        public int? Nok1PersonId { get; set; }
        public string Nok1Person { get; set; }
        public string Nok1Relationship { get; set; }
        public int? Nok2PersonId { get; set; }
        public string Nok2Person { get; set; }
        public string Nok2Relationship { get; set; }
        public int? AddresseeId { get; set; }
        public int? HouseholdId { get; set; }
        public string RecruitmentSource { get; set; }
        public string Comments { get; set; }
        public string PreferredContactVerbal { get; set; }
        public Boolean IsNok1ForKids { get; set; }
        public Boolean IsNok2ForKids { get; set; }
        public int? AgeInYrs { get; set; }
        public string AgeInYrMo { get; set; }

        //study Detail
        public int StudyId { get; set; }
        public string StudyNickName { get; set; }


        //Address
        public Boolean ActiveAddress { get; set; }
        public string BuildingUnit { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public DateTime? LastConfirmedWhen { get; set; }
        public int? LastConfirmedBy { get; set; }
        public String ConfirmedBy { get; set; }
        public String  PhoneHome{ get; set; }
        public int? HouseholdAddressee { get; set; }

        //Study participation Details
        public int SubjectStudyLinkId { get; set; }
        public String StudyParticipationStatus { get; set; }
        public String VisitStream { get; set; }
        public String Reason { get; set; }
        public String ReasonOther { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo{ get; set; }
        public string OfficialSubjectStudyNum { get; set; }

        public IEnumerable<ParticipantViewModel> HouseholdMembers { get; set; }
        public IEnumerable<CorrespondanceViewModel> Correspondance { get; set; }
        public IEnumerable<MedicalHistoryViewModel> MedicalHistory { get; set; }
        public IEnumerable<LinkedInformedConsentViewModel> InformedConsents { get; set; }
        public IEnumerable<LinkedSubjectDoctorPracticeViewModel> LinkedSubjectDoctorPractices { get; set; }

    }
}