using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    public class VisitSchedulesController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/VisitSchedules
        public IEnumerable<VisitScheduleViewModel> GetVisitSchedules()
        {
           var visitSchedule = db.VisitSchedules.ToArray();
           var visitScheduleList = Mapper.Map<VisitSchedule[], IEnumerable<VisitScheduleViewModel>>(visitSchedule);

            return visitScheduleList;
        }

        // GET: api/VisitSchedules/5
       // [ResponseType(typeof(VisitSchedule))]
        public VisitScheduleViewModel GetVisitSchedule(int id)
        {
            var visitSchedule = db.VisitSchedules.Find(id);
            var visitScheduleViewModel = Mapper.Map<VisitSchedule, VisitScheduleViewModel>(visitSchedule);

           
            //Vaccines
            var vaccines = db.VaccinationsByVisits.Where(v => v.VisitScheduleId == id).ToArray();
            var vaccinesViewModel = Mapper.Map<VaccinationsByVisit[], IEnumerable<VaccinationsByVisitViewModel>>(vaccines);

            foreach (var vac in vaccinesViewModel)
            {
                vac.VaccineName = db.VaccinationTypes.Find(vac.TypeVaccinationId).Description;

            }
            
                visitScheduleViewModel.VaccineList = vaccinesViewModel;


            //Samples
            var samples = db.SamplesByVisits.Where(s => s.VisitScheduleId == id).ToArray();
            var samplesViewModel = Mapper.Map<SamplesByVisit[], IEnumerable<SamplesByVisitViewModel>>(samples);
            foreach (var sam in samplesViewModel)
            {
                sam.SampleName = db.SampleTypes.Find(sam.TypeSampleId).Description;

            }

            visitScheduleViewModel.SampleList = samplesViewModel;

            //Travel
           var travel = db.TravelReimbursementsByVisits.Where(t => t.VisitScheduleId == id).ToArray();
           var travelViewModel = Mapper.Map<TravelReimbursementsByVisit[], IEnumerable<TravelReimbursementsByVisitViewModel>>(travel);
           visitScheduleViewModel.TravelList = travelViewModel;

            //Questionnaire
             var questionnaire = db.QuestionnairesByVisits.Where(q => q.VisitScheduleId == id).ToArray();
            var questionnaireViewModel = Mapper.Map<QuestionnairesByVisit[], IEnumerable<QuestionnaireByVisitViewModel>>(questionnaire);
            foreach (var question in questionnaireViewModel)
            {
                question.QuestionnaireTypeName = db.QuestionnaireTypes.Find(question.TypeQuestionnaireId).Description;
            }
            visitScheduleViewModel.QuestionList = questionnaireViewModel;


            return visitScheduleViewModel;
        }

        // PUT: api/VisitSchedules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisitSchedule(int id, VisitSchedule visitSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visitSchedule.VisitScheduleId)
            {
                return BadRequest();
            }

            db.Entry(visitSchedule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitScheduleExists(id))
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

        // POST: api/VisitSchedules
        [ResponseType(typeof(VisitSchedule))]
        public IHttpActionResult PostVisitSchedule(VisitSchedule visitSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VisitSchedules.Add(visitSchedule);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = visitSchedule.VisitScheduleId }, visitSchedule);
        }

        // DELETE: api/VisitSchedules/5
        [ResponseType(typeof(VisitSchedule))]
        public IHttpActionResult DeleteVisitSchedule(int id)
        {
            VisitSchedule visitSchedule = db.VisitSchedules.Find(id);
            if (visitSchedule == null)
            {
                return NotFound();
            }

            db.VisitSchedules.Remove(visitSchedule);
            db.SaveChanges();

            return Ok(visitSchedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitScheduleExists(int id)
        {
            return db.VisitSchedules.Count(e => e.VisitScheduleId == id) > 0;
        }
    }
}