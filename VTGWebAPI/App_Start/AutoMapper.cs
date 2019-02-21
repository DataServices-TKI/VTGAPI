using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VTGWebAPI.App_Data;
using VTGWebAPI.ViewModels;

namespace VTGWebAPI
{
    public class AutoMapper
    {
        public void Mapping()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Correspondence, CorrespondanceViewModel>();
                cfg.CreateMap<MedicalHistory, MedicalHistoryViewModel>();
                cfg.CreateMap<ParticipantConsentById, LinkedInformedConsentViewModel>();
                cfg.CreateMap<StudyDetailById, StudyViewModel>();
                cfg.CreateMap<Recruitment, RecruitmentViewModel>();
                cfg.CreateMap<InformedConsent, InformedConsentViewModel>();
                cfg.CreateMap<StaffRolesForStudy,LinkVtgStaffStudyViewModel>();
                cfg.CreateMap<VisitSchedule, VisitScheduleViewModel>();
            });

          


        }
        
    }
}