using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VTGWebAPI.App_Data;

namespace VTGWebAPI.ViewModels
{
    public class UserMapper
    {
        public UserViewModel GetuserViewModel(VtgStaff userModel)
        {
            var userViewModel = new UserViewModel();

            userViewModel.VtgStaffId                                              = userModel.VtgStaffId;
            userViewModel.Username                                                = userModel.Username;
            userViewModel.Password                                                = userModel.Password;
            userViewModel.CurrentStudy                                              = userModel.CurrentStudy;
         
            //userViewModel.DbConsentYesNo                                      = userModel.DbConsentYesNo;
            //userViewModel.DbConsentType                                       = userModel.DbConsentType;
            //userViewModel.DbConsentDateLastConfirmed                          = userModel.DbConsentDateLastConfirmed;  
            //userViewModel.NewsletterConsentYesNo                              = userModel.NewsletterConsentYesNo;
            //userViewModel.NewsletterConsentDateLastConfirmed                  = userModel.NewsletterConsentDateLastConfirmed;
            //userViewModel.FutureVtgResearchConsentYesNo                       = userModel.FutureVtgResearchConsentYesNo;
            //userViewModel.FutureVtgResearchConsentDateLastConfirmed           = userModel.FutureVtgResearchConsentDateLastConfirmed;
            //userViewModel.FutureThirdPartyResearchlConsentYesNo               = userModel.FutureThirdPartyResearchlConsentYesNo;
            //userViewModel.FutureThirdPartyResearchConsentDateLastConfirmed    = userModel.FutureThirdPartyResearchConsentDateLastConfirmed;
            //userViewModel.Title                                               = userModel.Title;
            //userViewModel.Surname                                             = userModel.Surname;
            //userViewModel.Firstname                                           = userModel.Firstname;
            //userViewModel.MiddleName                                          = userModel.MiddleName;
            //userViewModel.PreferredName                                       = userModel.PreferredName;
            //userViewModel.Gender                                              = userModel.Gender;
            //userViewModel.Dob                                                 = userModel.Dob;
            //userViewModel.Ethnicity                                           = userModel.Ethnicity;
            //userViewModel.PhoneWork                                           = userModel.PhoneWork;
            //userViewModel.PhoneMobile                                         = userModel.PhoneMobile;
            //userViewModel.Email                                               = userModel.Email;
            //userViewModel.PreferredContactWritten                             = userModel.PreferredContactWritten;
            //userViewModel.Nok1PersonId                                        = userModel.Nok1PersonId;
            //userViewModel.Nok1Relationship                                    = userModel.Nok1Relationship;
            //userViewModel.Nok2PersonId                                        = userModel.Nok2PersonId;
            //userViewModel.Nok2Relationship                                    = userModel.Nok2Relationship;
            //userViewModel.AddresseeId                                         = userModel.AddresseeId;
            //userViewModel.HouseholdId                                         = userModel.HouseholdId;
            //userViewModel.RecruitmentSource                                   = userModel.RecruitmentSource;
            //userViewModel.Comments                                            = userModel.Comments;
            //userViewModel.PreferredContactVerbal                              = userModel.PreferredContactVerbal;
            //userViewModel.IsNok1ForKids                                       = userModel.IsNok1ForKids;
            //userViewModel.IsNok2ForKids                                       = userModel.IsNok2ForKids;
            //userViewModel.AgeInYrs                                            = userModel.AgeInYrs;
            //userViewModel.AgeInYrMo                                           = userModel.AgeInYrMo;


            return userViewModel;

        }
        public VtgStaff GetuserModel(UserViewModel userViewModel)
        {
            var user = new VtgStaff();

            user.VtgStaffId                                            = userViewModel.VtgStaffId;
            user.Username                                              = userViewModel.Username;
            user.Password                                              = userViewModel.Password;
            //user.UMRN                                                = userViewModel.UMRN;
            //user.DbConsentYesNo                                      = userViewModel.DbConsentYesNo;
            //user.DbConsentType                                       = userViewModel.DbConsentType;
            //user.DbConsentDateLastConfirmed                          = userViewModel.DbConsentDateLastConfirmed;  
            //user.NewsletterConsentYesNo                              = userViewModel.NewsletterConsentYesNo;
            //user.NewsletterConsentDateLastConfirmed                  = userViewModel.NewsletterConsentDateLastConfirmed;
            //user.FutureVtgResearchConsentYesNo                       = userViewModel.FutureVtgResearchConsentYesNo;
            //user.FutureVtgResearchConsentDateLastConfirmed           = userViewModel.FutureVtgResearchConsentDateLastConfirmed;
            //user.FutureThirdPartyResearchlConsentYesNo               = userViewModel.FutureThirdPartyResearchlConsentYesNo;
            //user.FutureThirdPartyResearchConsentDateLastConfirmed    = userViewModel.FutureThirdPartyResearchConsentDateLastConfirmed;
            //user.Title                                               = userViewModel.Title;
            //user.Surname                                             = userViewModel.Surname;
            //user.Firstname                                           = userViewModel.Firstname;
            //user.MiddleName                                          = userViewModel.MiddleName;
            //user.PreferredName                                       = userViewModel.PreferredName;
            //user.Gender                                              = userViewModel.Gender;
            //user.Dob                                                 = userViewModel.Dob;
            //user.Ethnicity                                           = userViewModel.Ethnicity;
            //user.PhoneWork                                           = userViewModel.PhoneWork;
            //user.PhoneMobile                                         = userViewModel.PhoneMobile;
            //user.Email                                               = userViewModel.Email;
            //user.PreferredContactWritten                             = userViewModel.PreferredContactWritten;
            //user.Nok1PersonId                                        = userViewModel.Nok1PersonId;
            //user.Nok1Relationship                                    = userViewModel.Nok1Relationship;
            //user.Nok2PersonId                                        = userViewModel.Nok2PersonId;
            //user.Nok2Relationship                                    = userViewModel.Nok2Relationship;
            //user.AddresseeId                                         = userViewModel.AddresseeId;
            //user.HouseholdId                                         = userViewModel.HouseholdId;
            //user.RecruitmentSource                                   = userViewModel.RecruitmentSource;
            //user.Comments                                            = userViewModel.Comments;
            //user.PreferredContactVerbal                              = userViewModel.PreferredContactVerbal;
            //user.IsNok1ForKids                                       = userViewModel.IsNok1ForKids;
            //user.IsNok2ForKids                                       = userViewModel.IsNok2ForKids;
            //user.AgeInYrs                                            = userViewModel.AgeInYrs;
            //user.AgeInYrMo                                           = userViewModel.AgeInYrMo;

            return user;

        }

    }
}