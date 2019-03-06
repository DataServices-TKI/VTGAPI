using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VTGWebAPI.App_Data;
using VTGWebAPI.ViewModels;



namespace VTGWebAPI.Controllers
{
    public class ParticipantController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/Participant
        [Route("api/Participants")]
        public IEnumerable<ParticipantViewModel> GetPeople()
        {
            var participants = new List<ParticipantViewModel>();

            var participantList = db.GetParticipantList();
            var mapper = new ParticipantMapper();
            foreach (var p in participantList)
            {
                participants.Add(mapper.GetParticipantViewModel(p));

            }
            return participants;

        }


        // GET: api/Participants
        [Route("api/Participants/{studyId}/patientList")]
        public IEnumerable<ParticipantViewModel> GetPeopleBystudyId(string studyId)
        {
           var Id = Convert.ToInt32(studyId);
            var participants = new List<ParticipantViewModel>();

            var participantDetailList = from p in db.GetParticipantByStudyId(Id) select p;
            var participantList = Mapper.Map<IEnumerable<ParticipantDetail>, IEnumerable<ParticipantById>>(participantDetailList);

            var mapper = new ParticipantMapper();
            foreach (var p in participantList)
            {

                participants.Add(mapper.GetParticipantViewModel(p));
               //add study Details


           }

            return participants;

        }
        // GET: api/Participant/5
        [Route("api/Participant/{id}/{studyId}")]
        public ParticipantViewModel GetPerson(int id, int studyId)
        {
            var participant = new ParticipantViewModel();
            var mapper = new ParticipantMapper();
            var personDetail = new ParticipantDetail();
            var person = new ParticipantById();
            if (studyId==0)
            {
                
                person = db.GetParticipantById(id).FirstOrDefault();
            }
            else {
                person = db.GetParticipantById(id).Where(s => s.StudyId == studyId).FirstOrDefault();

            }
           
            if (person != null)
            {
                participant = mapper.GetParticipantViewModel(person);

                //HouseholdMembers
                if (participant.HouseholdId != null)
                {
                    var participantList = GetPeople();
                    participant.HouseholdMembers = participantList.Where(p => p.HouseholdId == participant.HouseholdId).ToList();
                }
                if (studyId != 0)
                {

                    #region StudyParticipation
                    var ic = db.GetParticipantConsentById(participant.PersonId).Where(s => s.StudyId == participant.StudyId).ToArray();
                    var informedConsents = Mapper.Map<ParticipantConsentById[], IEnumerable<LinkedInformedConsentViewModel>>(ic);

                    foreach (var i in informedConsents)
                    {
                        if (i.WrittenConsentBy.HasValue)
                        {
                            i.WrittenConsenByName = db.uspGetStaffFullNameById(i.WrittenConsentBy.Value).FirstOrDefault();
                        }
                        if (i.VerbalConsentBy.HasValue)
                        {
                            i.VerbalConsentByName = db.uspGetStaffFullNameById(i.VerbalConsentBy.Value).FirstOrDefault();
                        }
                    }

                    participant.InformedConsents = informedConsents.ToList();


                    #endregion
                    //Corresponsdance 
                    #region Corresponsdance
                    var userCorrespondance = db.Correspondences.Where(c => c.StudyId == studyId && c.PersonId == id).ToArray();

                    var correspondance = Mapper.Map<Correspondence[], IEnumerable<CorrespondanceViewModel>>(userCorrespondance);


                    foreach (var c in correspondance)
                    {
                        if (c.VtgStaffId.HasValue)
                        {
                            c.VtgStaff = db.uspGetStaffFullNameById(c.VtgStaffId.Value).FirstOrDefault();
                        }

                        if (c.FollowupStaff1.HasValue)
                        {
                            c.FollowupStaff = db.uspGetStaffFullNameById(c.FollowupStaff1.Value).FirstOrDefault();
                        }

                        if (c.FollowupStaff2.HasValue)
                        {
                            c.FollowupStaff = c.FollowupStaff + ',' + db.uspGetStaffFullNameById(c.FollowupStaff2.Value).FirstOrDefault();
                        }
                    }
                    participant.Correspondance = correspondance;
                    #endregion

                    #region Medical History
                    var medHistory = db.MedicalHistories.Where(m => m.PersonId == id).ToArray();

                    var medicalHistory = Mapper.Map<MedicalHistory[], IEnumerable<MedicalHistoryViewModel>>(medHistory);
                    foreach (var md in medicalHistory)
                    {


                    }
                    participant.MedicalHistory = medicalHistory;
                    #endregion

                }
                else {
                    #region Corresponsdance
                    var userCorrespondance = db.Correspondences.Where(c => c.StudyId == null && c.PersonId == id).ToArray();

                    var correspondance = Mapper.Map<Correspondence[], IEnumerable<CorrespondanceViewModel>>(userCorrespondance);


                    foreach (var c in correspondance)
                    {
                        if (c.VtgStaffId.HasValue)
                        {
                            c.VtgStaff = db.uspGetStaffFullNameById(c.VtgStaffId.Value).FirstOrDefault();
                        }

                        if (c.FollowupStaff1.HasValue)
                        {
                            c.FollowupStaff = db.uspGetStaffFullNameById(c.FollowupStaff1.Value).FirstOrDefault();
                        }

                        if (c.FollowupStaff2.HasValue)
                        {
                            c.FollowupStaff = c.FollowupStaff + ',' + db.uspGetStaffFullNameById(c.FollowupStaff2.Value).FirstOrDefault();
                        }
                    }
                    participant.Correspondance = correspondance;
                    #endregion

                }


                #region Practices/Doctors

                var linkedDocPractice = db.LinkSubjectDoctorPractices.Where(d => d.PersonId == id).ToList();
                    var linkedDocPracticeVM = Mapper.Map<List<LinkSubjectDoctorPractice>,IEnumerable<LinkedSubjectDoctorPracticeViewModel>>(linkedDocPractice);

                foreach(var link in linkedDocPracticeVM)
                {                   
                    var practiceDocs = db.LinkDoctorPractices.Where(p => p.DoctorPracticeLinkId == link.DoctorPracticeLinkId).FirstOrDefault();

                    //PracticeName
                    link.Practice = db.Practices.Where(p => p.PracticeId == practiceDocs.PracticeId).Select(p => p.NamePractice).FirstOrDefault();
                    link.PracticeId = practiceDocs.PracticeId;
                    //Doctor Detail
                    var doctor = db.Doctors.Where(d => d.DoctorId == practiceDocs.DoctorId).FirstOrDefault();
                    link.DoctorId = practiceDocs.DoctorId;
                    link.DoctorName = doctor.Fullname;
                    link.DoctorType = doctor.TypeDoctor;
                }
                participant.LinkedSubjectDoctorPractices = linkedDocPracticeVM;


                #endregion


                //Next of Kins
                //if (person.Nok1PersonId != null)
                //{
                //    participant.Nok1PersonId = person.Nok1PersonId;
                //    participant.Nok1Person = person.NoK1Person;
                //}
                //if (person.Nok2PersonId != null)
                //{
                //    participant.Nok2PersonId = person.Nok2PersonId;
                //    participant.Nok2Person = person.NoK2Person;
                //}


            }

            return participant;

        }

        // PUT: api/Participant/5      
        [Route("api/Participant/{id}")]
        public IHttpActionResult PutPerson(int id, ParticipantViewModel participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participant.PersonId)
            {
                return BadRequest();
            }
            var mapper = new ParticipantMapper();
            var person = mapper.GetParticipantModel(participant);
            if (participant.StudyId != 0)
            {
                var linkedStudy = db.LinkSubjectsStudies.Where(l => l.PersonId == participant.PersonId && l.StudyId == participant.StudyId).FirstOrDefault();
                //Study Detail
                linkedStudy.Status = participant.StudyParticipationStatus;
                linkedStudy.OfficialSubjectStudyNum = participant.OfficialSubjectStudyNum;
                linkedStudy.WithdrawnReason = participant.Reason;
                linkedStudy.WithdrawnReasonOther = participant.ReasonOther;
                linkedStudy.EffFrom = participant.EffectiveFrom;
                linkedStudy.EffTo = participant.EffectiveTo;
                linkedStudy.OfficialSubjectStudyNum = participant.OfficialSubjectStudyNum;
                db.Entry(linkedStudy).State = EntityState.Modified;

            }

            if (participant.HouseholdId.HasValue)
            {

           
            //Household Detail
            var household = db.Households.Where(h => h.HouseholdId == participant.HouseholdId).FirstOrDefault();
            household.AddressStreet = participant.Street;
            household.AddressSuburb = participant.Suburb;
            household.AddressPostcode = participant.Postcode;
            household.AddressState = participant.State;
            household.PhoneHome = participant.PhoneHome;
            household.LastConfirmedBy = participant.LastConfirmedBy;
            household.LastConfirmedWhen = participant.LastConfirmedWhen;
            household.AddresseeId = participant.HouseholdAddressee;
            household.ActiveAddress = participant.ActiveAddress?1:0;
            db.Entry(household).State = EntityState.Modified;

            }


            db.Entry(person).State = EntityState.Modified;
        
          

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Participant    
        public IHttpActionResult PostPerson(ParticipantViewModel participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Add HouseholdId
            if (participant.HouseholdId == null)
            {
                var household = new Household();
                household.AddressStreet = participant.Street;
                household.AddressSuburb = participant.Suburb;
                household.AddressPostcode = participant.Postcode;
                household.AddressState = participant.State;
                household.PhoneHome = participant.PhoneHome;
                household.LastConfirmedBy = participant.LastConfirmedBy;
                household.LastConfirmedWhen = participant.LastConfirmedWhen;
                household.AddresseeId = participant.HouseholdAddressee;
                household.ActiveAddress = household.ActiveAddress;
                db.Households.Add(household);
                db.SaveChanges();

                participant.HouseholdId = db.Households.Max(x => x.HouseholdId);
            }
                
            //Add Participant
            var mapper = new ParticipantMapper();
            var person = mapper.GetParticipantModel(participant);
            db.People.Add(person);
            db.SaveChanges();

            if (participant.StudyId != 0)
            {
                //Add in Linked Stuby Table
                var linkedStudy = new LinkSubjectsStudy();
                linkedStudy.PersonId = db.People.Max(x => x.PersonId);
                linkedStudy.StudyId = participant.StudyId;
                db.LinkSubjectsStudies.Add(linkedStudy);
                db.SaveChanges();
            }

           
            return Ok(participant);
        }

        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            db.People.Remove(person);
            db.SaveChanges();

            return Ok(person);
        }





        [Route("api/Participants/Correspondances")]
        public IHttpActionResult PostPateintCorrespondence(CorrespondanceViewModel corresVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var correpondence = Mapper.Map<CorrespondanceViewModel, Correspondence>(corresVM);
            db.Correspondences.Add(correpondence);
            db.SaveChanges();

            return Ok(correpondence);
        }


        [Route("api/Participants/Correspondances/{id}")]
        public CorrespondanceViewModel GetPateintCorrespondenceDetail(int id)
        {
            var corres = db.Correspondences.Find(id);
            var corresVM = Mapper.Map<Correspondence, CorrespondanceViewModel>(corres);

            return corresVM;
        }


        [Route("api/Participants/Correspondances/{id}")]
        public IHttpActionResult PutPateintCorrespondence(int id, CorrespondanceViewModel corresVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != corresVM.CorrespondenceId)
            {
                return BadRequest();
            }

            var corres = Mapper.Map<CorrespondanceViewModel, Correspondence>(corresVM);

            db.Entry(corres).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);


        }

        [Route("api/Participants/Correspondances/{id}")]
        public IHttpActionResult DeleteInformedCorrespondence(int id)
        {
            Correspondence corres = db.Correspondences.Find(id);
            if (corres == null)
            {
                return NotFound();
            }

            db.Correspondences.Remove(corres);
            db.SaveChanges();

            return Ok(corres);

        }





        [Route("api/Participants/InformedConsents")]         
        public IHttpActionResult PostPateintConsents(LinkedInformedConsentViewModel informedConsentVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var informedConsent = new LinkSubjectStudyInformedConsent()
            {
                SubjectStudyLinkId = informedConsentVM.SubjectStudyLinkId,
                InformedConsentId = informedConsentVM.InformedConsentId,
                VerbalConsentDate = informedConsentVM.VerbalConsentDate,
                VerbalConsentBy = informedConsentVM.VerbalConsentBy,
                WrittenConsentDate = informedConsentVM.WrittenConsentDate,
                WrittenConsentBy = informedConsentVM.WrittenConsentBy,
                Status = informedConsentVM.Status

            };
            
           // var informedConsent = Mapper.Map<LinkedInformedConsentViewModel, LinkSubjectStudyInformedConsent>(informedConsentVM);
            db.LinkSubjectStudyInformedConsents.Add(informedConsent);
            db.SaveChanges();

            return Ok(informedConsent);

        }

        [Route("api/Participants/InformedConsents/{id}")]
        public IHttpActionResult PutPateintConsent(int id, LinkedInformedConsentViewModel informedConsentVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != informedConsentVM.SubjectStudyInformedConsentLinkId)
            {
                return BadRequest();
            }

            var informedConsent = new LinkSubjectStudyInformedConsent()
            {
                SubjectStudyInformedConsentLinkId = informedConsentVM.SubjectStudyInformedConsentLinkId,
                SubjectStudyLinkId = informedConsentVM.SubjectStudyLinkId,
                InformedConsentId = informedConsentVM.InformedConsentId,
                VerbalConsentDate = informedConsentVM.VerbalConsentDate,
                VerbalConsentBy = informedConsentVM.VerbalConsentBy,
                WrittenConsentDate = informedConsentVM.WrittenConsentDate,
                WrittenConsentBy = informedConsentVM.WrittenConsentBy,
                Status = informedConsentVM.Status

            };

            db.Entry(informedConsent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        

    }

        [Route("api/Participants/InformedConsents/{id}")]
        public LinkedInformedConsentViewModel GetPateintConsentDetail(int id)
        {
            var consent = db.LinkSubjectStudyInformedConsents.Find(id);
            // var consentVM = Mapper.Map<LinkSubjectStudyInformedConsent, LinkedInformedConsentViewModel>(consent);
            var consentVM = new LinkedInformedConsentViewModel();
            
                consentVM.SubjectStudyInformedConsentLinkId = consent.SubjectStudyInformedConsentLinkId;
                consentVM.SubjectStudyLinkId = consent.SubjectStudyLinkId;
                consentVM.InformedConsentId = consent.InformedConsentId;
                consentVM.Status = consent.Status;
                consentVM.VerbalConsentBy = consent.VerbalConsentBy;
                consentVM.VerbalConsentDate = consent.VerbalConsentDate;
                consentVM.WrittenConsentBy = consent.WrittenConsentBy;
                consentVM.WrittenConsentDate = consent.WrittenConsentDate;

           
            return consentVM;
        }


        [Route("api/Participants/InformedConsents/{id}")]
        public IHttpActionResult DeleteInformedConsent(int id)
        {
            LinkSubjectStudyInformedConsent consent = db.LinkSubjectStudyInformedConsents.Find(id);
            if (consent == null)
            {
                return NotFound();
            }

            db.LinkSubjectStudyInformedConsents.Remove(consent);
            db.SaveChanges();

            return Ok(consent);

        }



        //Linked Doctors and Practices

        [Route("api/Participants/LinkedDoctorPractice")]
        public IHttpActionResult PostPateintLinkDoctorPractice(LinkedSubjectDoctorPracticeViewModel linkedDocVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            linkedDocVM.DoctorPracticeLinkId = db.LinkDoctorPractices.Where(l => l.DoctorId == linkedDocVM.DoctorId && l.PracticeId == linkedDocVM.PracticeId).Select(l => l.DoctorPracticeLinkId).FirstOrDefault();

            var linkedDocPrac = Mapper.Map<LinkedSubjectDoctorPracticeViewModel, LinkSubjectDoctorPractice>(linkedDocVM);
            db.LinkSubjectDoctorPractices.Add(linkedDocPrac);
            db.SaveChanges();

            return Ok(linkedDocPrac);

        }

        [Route("api/Participants/LinkedDoctorPractice/{id}")]
        public IHttpActionResult DeleteLinkedPracticeDoctor(int id)
        {
            LinkSubjectDoctorPractice linkedDoc = db.LinkSubjectDoctorPractices.Find(id);
            if (linkedDoc == null)
            {
                return NotFound();
            }

            db.LinkSubjectDoctorPractices.Remove(linkedDoc);
            db.SaveChanges();

            return Ok(linkedDoc);

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.People.Count(e => e.PersonId == id) > 0;
        }
    }
}