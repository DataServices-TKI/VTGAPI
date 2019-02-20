﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class VTGEntities : DbContext
    {
        public VTGEntities()
            : base("name=VTGEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdverseEvent> AdverseEvents { get; set; }
        public virtual DbSet<AnalysisLocation> AnalysisLocations { get; set; }
        public virtual DbSet<AppParameter> AppParameters { get; set; }
        public virtual DbSet<AppValueList> AppValueLists { get; set; }
        public virtual DbSet<AppValueListData> AppValueListDatas { get; set; }
        public virtual DbSet<BodySystem> BodySystems { get; set; }
        public virtual DbSet<Correspondence> Correspondences { get; set; }
        public virtual DbSet<Diagnosis> Diagnoses { get; set; }
        public virtual DbSet<DiagnosesIcd> DiagnosesIcds { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<dtproperty> dtproperties { get; set; }
        public virtual DbSet<EthicsApplication> EthicsApplications { get; set; }
        public virtual DbSet<EthicsApplicationSubDoc> EthicsApplicationSubDocs { get; set; }
        public virtual DbSet<Household> Households { get; set; }
        public virtual DbSet<InformedConsent> InformedConsents { get; set; }
        public virtual DbSet<LinkDoctorPractice> LinkDoctorPractices { get; set; }
        public virtual DbSet<LinkSubjectDoctorPractice> LinkSubjectDoctorPractices { get; set; }
        public virtual DbSet<LinkSubjectMedication> LinkSubjectMedications { get; set; }
        public virtual DbSet<LinkSubjectsStudy> LinkSubjectsStudies { get; set; }
        public virtual DbSet<LinkSubjectStudyInformedConsent> LinkSubjectStudyInformedConsents { get; set; }
        public virtual DbSet<LinkVtgStaffStudy> LinkVtgStaffStudies { get; set; }
        public virtual DbSet<LinkVtgStaffStudyRole> LinkVtgStaffStudyRoles { get; set; }
        public virtual DbSet<MedicalHistory> MedicalHistories { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<ParticipantConsent> ParticipantConsents { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Postcode> Postcodes { get; set; }
        public virtual DbSet<Practice> Practices { get; set; }
        public virtual DbSet<QuestionnaireResult> QuestionnaireResults { get; set; }
        public virtual DbSet<QuestionnaireResultsType> QuestionnaireResultsTypes { get; set; }
        public virtual DbSet<Questionnaire> Questionnaires { get; set; }
        public virtual DbSet<QuestionnairesByVisit> QuestionnairesByVisits { get; set; }
        public virtual DbSet<QuestionnaireType> QuestionnaireTypes { get; set; }
        public virtual DbSet<Recruitment> Recruitments { get; set; }
        public virtual DbSet<RegisteredNurs> RegisteredNurses { get; set; }
        public virtual DbSet<Sample> Samples { get; set; }
        public virtual DbSet<SamplesByVisit> SamplesByVisits { get; set; }
        public virtual DbSet<SampleType> SampleTypes { get; set; }
        public virtual DbSet<Study> Studies { get; set; }
        public virtual DbSet<StudyRole> StudyRoles { get; set; }
        public virtual DbSet<SubSampleResult> SubSampleResults { get; set; }
        public virtual DbSet<SubSampleResultsType> SubSampleResultsTypes { get; set; }
        public virtual DbSet<SubSample> SubSamples { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TravelReimbursement> TravelReimbursements { get; set; }
        public virtual DbSet<TravelReimbursementsByVisit> TravelReimbursementsByVisits { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }
        public virtual DbSet<VaccinationsByVisit> VaccinationsByVisits { get; set; }
        public virtual DbSet<VaccinationType> VaccinationTypes { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<VisitSchedule> VisitSchedules { get; set; }
        public virtual DbSet<VtgStaff> VtgStaffs { get; set; }
        public virtual DbSet<VtgStaffLocation> VtgStaffLocations { get; set; }
        public virtual DbSet<VtgStaffRequirement> VtgStaffRequirements { get; set; }
        public virtual DbSet<VtgStaffRequirementType> VtgStaffRequirementTypes { get; set; }
        public virtual DbSet<DatabaseSetting> DatabaseSettings { get; set; }
        public virtual DbSet<GetRecruitmentSource> GetRecruitmentSources { get; set; }
    
        public virtual ObjectResult<ParticipantDetail> GetParticipantList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ParticipantDetail>("GetParticipantList");
        }
    
        public virtual ObjectResult<ParticipantDetail> GetParticipantById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ParticipantDetail>("GetParticipantById", idParameter);
        }
    
        public virtual ObjectResult<Study> GetStudyList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Study>("GetStudyList");
        }
    
        public virtual ObjectResult<Study> GetStudyList(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Study>("GetStudyList", mergeOption);
        }
    
        public virtual ObjectResult<ParticipantDetail> GetParticipantByStudyId(Nullable<int> studyId)
        {
            var studyIdParameter = studyId.HasValue ?
                new ObjectParameter("StudyId", studyId) :
                new ObjectParameter("StudyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ParticipantDetail>("GetParticipantByStudyId", studyIdParameter);
        }
    
        public virtual ObjectResult<string> uspGetStaffFullNameById(Nullable<int> vtgStaffId)
        {
            var vtgStaffIdParameter = vtgStaffId.HasValue ?
                new ObjectParameter("vtgStaffId", vtgStaffId) :
                new ObjectParameter("vtgStaffId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspGetStaffFullNameById", vtgStaffIdParameter);
        }
    
        public virtual ObjectResult<ParticipantConsentById> GetParticipantConsentById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ParticipantConsentById>("GetParticipantConsentById", idParameter);
        }
    }
}
