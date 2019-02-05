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
        public IHttpActionResult PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonId)
            {
                return BadRequest();
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
    
        public IHttpActionResult PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(person);
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