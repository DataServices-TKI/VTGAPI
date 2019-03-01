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
    public class QuestionnairesController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/Questionnaires
        public IQueryable<Questionnaire> GetQuestionnaires()
        {
            return db.Questionnaires;
        }

        // GET: api/Questionnaires/5
        [ResponseType(typeof(Questionnaire))]
        public QuestionViewModel GetQuestionnaire(int id)
        {
            Questionnaire questionnaire = db.Questionnaires.Find(id);
         
            if (questionnaire == null)
            {
                return null;
            }
            var questionVM = Mapper.Map<Questionnaire, QuestionViewModel>(questionnaire);

            return questionVM;
        }

        // PUT: api/Questionnaires/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionnaire(int id, Questionnaire questionnaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionnaire.QuestionnaireId)
            {
                return BadRequest();
            }
            questionnaire.Description = db.QuestionnaireTypes.Find(questionnaire.TypeQuestionnaireId).Description;
            db.Entry(questionnaire).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireExists(id))
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

        // POST: api/Questionnaires
        [ResponseType(typeof(Questionnaire))]
        public IHttpActionResult PostQuestionnaire(Questionnaire questionnaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            questionnaire.Description = db.QuestionnaireTypes.Find(questionnaire.TypeQuestionnaireId).Description;
            db.Questionnaires.Add(questionnaire);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = questionnaire.QuestionnaireId }, questionnaire);
        }

        // DELETE: api/Questionnaires/5
        [ResponseType(typeof(Questionnaire))]
        public IHttpActionResult DeleteQuestionnaire(int id)
        {
            Questionnaire questionnaire = db.Questionnaires.Find(id);
            if (questionnaire == null)
            {
                return NotFound();
            }

            db.Questionnaires.Remove(questionnaire);
            db.SaveChanges();

            return Ok(questionnaire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionnaireExists(int id)
        {
            return db.Questionnaires.Count(e => e.QuestionnaireId == id) > 0;
        }
    }
}