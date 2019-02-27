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

            var participantList = from p in db.GetParticipantByStudyId(Id) select p;

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
            var person = db.GetParticipantById(id).Where(s=>s.StudyId==studyId).FirstOrDefault();
            if (person != null)
            {
                participant = mapper.GetParticipantViewModel(person);

                //HouseholdMembers
                if (participant.HouseholdId != null)
                {
                    var participantList = GetPeople();
                    participant.HouseholdMembers = participantList.Where(p => p.HouseholdId == participant.HouseholdId).ToList();
                }

                #region StudyParticipation
                var ic = db.GetParticipantConsentById(participant.PersonId).Where(s=>s.StudyId==participant.StudyId).ToArray();
                var informedConsents = Mapper.Map< ParticipantConsentById[], IEnumerable<LinkedInformedConsentViewModel>>(ic);

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
                            c.FollowupStaff = c.FollowupStaff +',' + db.uspGetStaffFullNameById(c.FollowupStaff2.Value).FirstOrDefault(); 
                        }
                    }
                    participant.Correspondance = correspondance;
                #endregion

                #region Medical History
                        var medHistory = db.MedicalHistories.Where(m => m.PersonId == id).ToArray();

                        var medicalHistory= Mapper.Map<MedicalHistory[], IEnumerable<MedicalHistoryViewModel>>(medHistory);
                        foreach (var md in medicalHistory)
                        {
                  

                        }
                        participant.MedicalHistory = medicalHistory;
                #endregion
                #region Practices/Doctors

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
            var linkedStudy = db.LinkSubjectsStudies.Where(l => l.PersonId == participant.PersonId && l.StudyId == participant.StudyId).FirstOrDefault();
            //Study Detail
            linkedStudy.Status = participant.StudyParticipationStatus;
            linkedStudy.OfficialSubjectStudyNum = participant.OfficialSubjectStudyNum;
            linkedStudy.WithdrawnReason = participant.Reason;
            linkedStudy.WithdrawnReasonOther = participant.ReasonOther;
            linkedStudy.EffFrom = participant.EffectiveFrom;
            linkedStudy.EffTo = participant.EffectiveTo;
            linkedStudy.OfficialSubjectStudyNum = participant.OfficialSubjectStudyNum;

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
        
            db.Entry(linkedStudy).State = EntityState.Modified;

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

            //Add in Linked Stuby Table
            var linkedStudy = new LinkSubjectsStudy();
            linkedStudy.PersonId = db.People.Max(x => x.PersonId);
            linkedStudy.StudyId = participant.StudyId;
            db.LinkSubjectsStudies.Add(linkedStudy);

        


            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.PersonId }, person);
        }

        // DELETE: api/Participant/5
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