using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VTGWebAPI.App_Data;


namespace VTGWebAPI.ViewModels
{
    public class StudyMapper
    {
        //Change Model to ViewModel
        public StudyViewModel GetStudyViewModel(Study study)
        {

            var studyViewModel = new StudyViewModel();

            studyViewModel.StudyId = study.StudyId;
            studyViewModel.NameStudy = study.NameStudy;
            studyViewModel.NicknameStudy = study.NicknameStudy;
            studyViewModel.StudyType = study.StudyType;
            studyViewModel.StudyCoordinator = study.StudyCoordinator;
            studyViewModel.ExpNumSubjects = study.ExpNumSubjects;
            studyViewModel.RecruitmentStartDate = study.RecruitmentStartDate;
            studyViewModel.RecruitmentEndDate = study.RecruitmentEndDate;

            studyViewModel.FirstVisitStartDate = study.FirstVisitEndDate;
            studyViewModel.FirstVisitEndDate = study.FirstVisitEndDate;
            studyViewModel.SubjectMinAgeInYears = study.SubjectMinAgeInYears;
            studyViewModel.SubjectMinAgeInequality = study.SubjectMinAgeInequality;
            studyViewModel.SubjectMaxAgeInYears = study.SubjectMaxAgeInYears;
            studyViewModel.SubjectMaxAgeInequality = study.SubjectMaxAgeInequality;
            studyViewModel.BackgroundInfo = study.BackgroundInfo;
            studyViewModel.IsCompletedYN = study.IsCompletedYN;
            studyViewModel.LastVisitEndDate = study.LastVisitEndDate;
            //studyViewModel.OfficialStartDate = study.
            //studyViewModel.OfficialEndDate = study.
            //studyViewModel.GpMailoutStudyTitle = study.
            //studyViewModel.GpMailoutStudyInfo = study.
            //studyViewModel.GpMailoutStudyObjectives = study.
            studyViewModel.StudyIsCurrentlyBlindedYN =((study.StudyIsCurrentlyBlindedYN.HasValue && study.StudyIsCurrentlyBlindedYN.Value==1)?true:false);
           // studyViewModel.IsSponsoredYN = study.

            return studyViewModel;
        }

        public Study GetStudy(StudyViewModel studyViewModel)
        {

            var study = new Study();

            study.StudyId = studyViewModel.StudyId;
            study.NameStudy = studyViewModel.NameStudy;
            study.NicknameStudy = studyViewModel.NicknameStudy;
            study.StudyType = studyViewModel.StudyType;
            study.StudyCoordinator = studyViewModel.StudyCoordinator;
            study.ExpNumSubjects =(short)(studyViewModel.ExpNumSubjects.HasValue? studyViewModel.ExpNumSubjects.Value:0);
            study.RecruitmentStartDate = studyViewModel.RecruitmentStartDate;
            study.RecruitmentEndDate = studyViewModel.RecruitmentEndDate;
            study.FirstVisitStartDate = studyViewModel.FirstVisitEndDate;
            study.FirstVisitEndDate = studyViewModel.FirstVisitEndDate;
            study.SubjectMinAgeInYears = studyViewModel.SubjectMinAgeInYears;
            study.SubjectMinAgeInequality = studyViewModel.SubjectMinAgeInequality;
            study.SubjectMaxAgeInYears = studyViewModel.SubjectMaxAgeInYears;
            study.SubjectMaxAgeInequality = studyViewModel.SubjectMaxAgeInequality;
            study.BackgroundInfo = studyViewModel.BackgroundInfo;
            study.IsCompletedYN = studyViewModel.IsCompletedYN;
            study.LastVisitEndDate = studyViewModel.LastVisitEndDate;
            study.OfficialStartDate = studyViewModel.OfficialStartDate;
            study.OfficialEndDate = studyViewModel.OfficialEndDate;
            study.GpMailoutStudyTitle = studyViewModel.GpMailoutStudyTitle;
            study.GpMailoutStudyInfo = studyViewModel.GpMailoutStudyInfo;
            study.GpMailoutStudyObjectives = studyViewModel.GpMailoutStudyObjectives;
            study.StudyIsCurrentlyBlindedYN = ((studyViewModel.StudyIsCurrentlyBlindedYN.HasValue && studyViewModel.StudyIsCurrentlyBlindedYN.Value ) ? 1 : 0);
            study.IsSponsoredYN = studyViewModel.IsSponsoredYN;

            return study;
        }
    }
}