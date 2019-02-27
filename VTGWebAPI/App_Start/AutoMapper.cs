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
                cfg.CreateMap<LinkVtgStaffStudyViewModel, LinkSubjectStudyInformedConsent>();
                cfg.CreateMap<LinkSubjectStudyInformedConsent, LinkVtgStaffStudyViewModel>();
                cfg.CreateMap<StudyDetailById, StudyViewModel>();
                cfg.CreateMap<StudyViewModel, Study>();
                cfg.CreateMap<Recruitment, RecruitmentViewModel>();
                cfg.CreateMap<RecruitmentViewModel, Recruitment>();
                cfg.CreateMap<InformedConsent, InformedConsentViewModel>();
                cfg.CreateMap<InformedConsentViewModel, InformedConsent>();
                cfg.CreateMap<StaffRolesForStudy,LinkVtgStaffStudyViewModel>();
                cfg.CreateMap<VtgStaff, VtgStaffViewModel>();
                cfg.CreateMap<StudyRole, StudyRoleViewModel>();
                cfg.CreateMap<LinkVtgStaffStudyViewModel, LinkVtgStaffStudy>();
                cfg.CreateMap<LinkVtgStaffStudy, LinkVtgStaffStudyViewModel>();
                cfg.CreateMap<StudyVisitTasks, VisitScheduleViewModel> ();
                cfg.CreateMap<VisitSchedule, VisitScheduleViewModel>();
                cfg.CreateMap<Visit, VisitViewModel>();
                cfg.CreateMap<VisitViewModel,Visit>();
                cfg.CreateMap<VaccinationsByVisit, VaccinationsByVisitViewModel>();
                cfg.CreateMap<SamplesByVisit, SamplesByVisitViewModel>();
                cfg.CreateMap<TravelReimbursementsByVisit, TravelReimbursementsByVisitViewModel>();
                cfg.CreateMap<QuestionnairesByVisit, QuestionnaireByVisitViewModel>();
                cfg.CreateMap<Practice, PracticesViewModel>();
                cfg.CreateMap<Doctor, DoctorsViewModel>();
            });

          


        }
        
    }
}