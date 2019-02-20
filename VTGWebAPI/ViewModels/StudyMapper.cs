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
            //studyViewModel.FirstVisitStartDate = study.
            //studyViewModel.FirstVisitEndDate = study.
            //studyViewModel.SubjectMinAgeInYears = study.
            //studyViewModel.SubjectMinAgeInequality = study.
            //studyViewModel.SubjectMaxAgeInYears = study.
            //studyViewModel.SubjectMaxAgeInequality = study.
            //studyViewModel.BackgroundInfo = study.
            //studyViewModel.IsCompletedYN = study.
            //studyViewModel.LastVisitEndDate = study.
            //studyViewModel.OfficialStartDate = study.
            //studyViewModel.OfficialEndDate = study.
            //studyViewModel.GpMailoutStudyTitle = study.
            //studyViewModel.GpMailoutStudyInfo = study.
            //studyViewModel.GpMailoutStudyObjectives = study.
            //studyViewModel.StudyIsCurrentlyBlindedYN = study.
            //studyViewModel.IsSponsoredYN = study.

            return studyViewModel;
    }
    }
}