using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VTGWebAPI.App_Data;

namespace VTGWebAPI.ViewModels
{
    public class ParticipantMapper
    {

        //Change Model to ViewModel
        public ParticipantViewModel GetParticipantViewModel(ParticipantDetail participantModel)
        {
            var participantViewModel = new ParticipantViewModel();

            participantViewModel.PersonId                                            = participantModel.PersonId;
            participantViewModel.VtgNumber                                           = participantModel.VtgNumber;
            participantViewModel.UMRN                                                = participantModel.UMRN;
            participantViewModel.DbConsentYesNo                                      = participantModel.DbConsentYesNo;
            participantViewModel.DbConsentType                                       = participantModel.DbConsentType;
            participantViewModel.DbConsentDateLastConfirmed                          = participantModel.DbConsentDateLastConfirmed;  
            participantViewModel.NewsletterConsentYesNo                              = participantModel.NewsletterConsentYesNo;
            participantViewModel.NewsletterConsentDateLastConfirmed                  = participantModel.NewsletterConsentDateLastConfirmed;
            participantViewModel.FutureVtgResearchConsentYesNo                       = participantModel.FutureVtgResearchConsentYesNo;
            participantViewModel.FutureVtgResearchConsentDateLastConfirmed           = participantModel.FutureVtgResearchConsentDateLastConfirmed;
            participantViewModel.FutureThirdPartyResearchlConsentYesNo               = participantModel.FutureThirdPartyResearchlConsentYesNo;
            participantViewModel.FutureThirdPartyResearchConsentDateLastConfirmed    = participantModel.FutureThirdPartyResearchConsentDateLastConfirmed;
            participantViewModel.Title                                               = participantModel.Title;
            participantViewModel.Surname                                             = participantModel.Surname;
            participantViewModel.Firstname                                           = participantModel.Firstname;
            participantViewModel.MiddleName                                          = participantModel.MiddleName;
            participantViewModel.PreferredName                                       = participantModel.PreferredName;
            participantViewModel.Gender                                              = participantModel.Gender;
            participantViewModel.Dob                                                 = participantModel.Dob;
            participantViewModel.Ethnicity                                           = participantModel.Ethnicity;
            participantViewModel.PhoneWork                                           = participantModel.PhoneWork;
            participantViewModel.PhoneMobile                                         = participantModel.PhoneMobile;
            participantViewModel.Email                                               = participantModel.Email;
            participantViewModel.PreferredContactWritten                             = participantModel.PreferredContactWritten;
            participantViewModel.Nok1PersonId                                        = participantModel.Nok1PersonId;     
            participantViewModel.Nok1Relationship                                    = participantModel.Nok1Relationship;
            participantViewModel.Nok2PersonId                                        = participantModel.Nok2PersonId;
            participantViewModel.Nok2Relationship                                    = participantModel.Nok2Relationship;
            participantViewModel.AddresseeId                                         = participantModel.AddresseeId;
            participantViewModel.HouseholdId                                         = participantModel.HouseholdId;
            participantViewModel.RecruitmentSource                                   = participantModel.RecruitmentSource;
            participantViewModel.Comments                                            = participantModel.Comments;
            participantViewModel.PreferredContactVerbal                              = participantModel.PreferredContactVerbal;
            participantViewModel.IsNok1ForKids                                       = ((participantModel.IsNok1ForKids.HasValue && participantModel.IsNok1ForKids==1)?true:false);
            participantViewModel.IsNok2ForKids                                       = ((participantModel.IsNok2ForKids.HasValue && participantModel.IsNok2ForKids ==1) ? true : false);
            participantViewModel.AgeInYrs                                            = participantModel.AgeInYrs;
            participantViewModel.AgeInYrMo                                           = participantModel.AgeInYrMo;
            participantViewModel.StudyNickName                                       = participantModel.NicknameStudy;
            participantViewModel.StudyId                                             = participantModel.StudyId.HasValue?participantModel.StudyId.Value:0;

            //Address
            participantViewModel.ActiveAddress                                       = participantModel.ActiveAddress.HasValue && participantModel.ActiveAddress==1?true:false;
            participantViewModel.State                                               = participantModel.AddressState;
            participantViewModel.Suburb                                              = participantModel.AddressSuburb;
            participantViewModel.Postcode                                            = participantModel.AddressPostcode;
            participantViewModel.Street                                              = participantModel.AddressStreet;
            participantViewModel.ActiveAddress                                       = (participantModel.ActiveAddress==1?true:false);
            participantViewModel.LastConfirmedWhen                                   = participantModel.LastConfirmedWhen;
            participantViewModel.LastConfirmedBy                                     = participantModel.LastConfirmedBy;
            participantViewModel.ConfirmedBy                                         = participantModel.ConfirmedBy;
            participantViewModel.PhoneHome                                           = participantModel.PhoneHome;
            participantViewModel.HouseholdAddressee                                  = participantModel.HouseholdAddressee;
          //  participantViewModel.PhoneHome = participantModel.PhoneHome;


            participantViewModel.StudyParticipationStatus                            = participantModel.Status;
            participantViewModel.OfficialSubjectStudyNum                             = participantModel.OfficialSubjectStudyNum;
          //  participantViewModel.VisitStream                                         = participantModel.VisitStream;
            participantViewModel.Reason                                              = participantModel.WithdrawnReason;
            participantViewModel.ReasonOther                                         = participantModel.WithdrawnReasonOther;
            participantViewModel.EffectiveFrom                                       = participantModel.EffFrom;
            participantViewModel.EffectiveTo                                         = participantModel.EffTo;

            



            return participantViewModel;

        }
        
        //Change ViewModel to Model
        public Person GetParticipantModel(ParticipantViewModel participantViewModel)
        {
            var participant = new Person();

            participant.PersonId                                            = participantViewModel.PersonId;
            participant.VtgNumber                                           = participantViewModel.VtgNumber;
            participant.VtgNumber                                           = participantViewModel.VtgNumber;
            participant.UMRN                                                = participantViewModel.UMRN;
            participant.DbConsentYesNo                                      = participantViewModel.DbConsentYesNo;
            participant.DbConsentType                                       = participantViewModel.DbConsentType;
            participant.DbConsentDateLastConfirmed                          = participantViewModel.DbConsentDateLastConfirmed;  
            participant.NewsletterConsentYesNo                              = participantViewModel.NewsletterConsentYesNo;
            participant.NewsletterConsentDateLastConfirmed                  = participantViewModel.NewsletterConsentDateLastConfirmed;
            participant.FutureVtgResearchConsentYesNo                       = participantViewModel.FutureVtgResearchConsentYesNo;
            participant.FutureVtgResearchConsentDateLastConfirmed           = participantViewModel.FutureVtgResearchConsentDateLastConfirmed;
            participant.FutureThirdPartyResearchlConsentYesNo               = participantViewModel.FutureThirdPartyResearchlConsentYesNo;
            participant.FutureThirdPartyResearchConsentDateLastConfirmed    = participantViewModel.FutureThirdPartyResearchConsentDateLastConfirmed;
            participant.Title                                               = participantViewModel.Title;
            participant.Surname                                             = participantViewModel.Surname;
            participant.Firstname                                           = participantViewModel.Firstname;
            participant.MiddleName                                          = participantViewModel.MiddleName;
            participant.PreferredName                                       = participantViewModel.PreferredName;
            participant.Gender                                              = participantViewModel.Gender;
            participant.Dob                                                 = participantViewModel.Dob;
            participant.Ethnicity                                           = participantViewModel.Ethnicity;
            participant.PhoneWork                                           = participantViewModel.PhoneWork;
            participant.PhoneMobile                                         = participantViewModel.PhoneMobile;
            participant.Email                                               = participantViewModel.Email;
            participant.PreferredContactWritten                             = participantViewModel.PreferredContactWritten;
            participant.Nok1PersonId                                        = participantViewModel.Nok1PersonId;          
            participant.Nok1Relationship                                    = participantViewModel.Nok1Relationship;
            participant.Nok2PersonId                                        = participantViewModel.Nok2PersonId;
            participant.Nok2Relationship                                    = participantViewModel.Nok2Relationship;
            participant.AddresseeId                                          = participantViewModel.AddresseeId;
            participant.HouseholdId                                         = participantViewModel.HouseholdId;
            participant.RecruitmentSource                                   = participantViewModel.RecruitmentSource;
            participant.Comments                                            = participantViewModel.Comments;
            participant.PreferredContactVerbal                              = participantViewModel.PreferredContactVerbal;
            participant.IsNok1ForKids                                       = participantViewModel.IsNok1ForKids?1:0;
            participant.IsNok2ForKids                                       = participantViewModel.IsNok2ForKids?1:0;
            participant.AgeInYrs                                            = participantViewModel.AgeInYrs;
            participant.AgeInYrMo                                           = participantViewModel.AgeInYrMo;
            



            return participant;

        }

    }
}