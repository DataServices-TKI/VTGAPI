using AutoMapper;
using System;
using System.Collections;
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
    public class AppValueListDataController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/AppValueListData
        public IEnumerable<AppValueListData> GetAppValueListDatas(string type)
        {
            var list = db.AppValueListDatas.Where(s => s.AppValueListData1 == type).ToList();
            return list;
        }


        // GET: api/AppValueListData/5
       // [ResponseType(typeof(AppValueListData))]
        public IEnumerable<AppValueListData> GetAppValueListData(int id)
        {
            var  appValueListData = db.AppValueListDatas.Where(s=>s.AppValueListId==id).OrderBy(s=>s.SortOrder).ToList();
          
           return appValueListData;
        }

        // PUT: api/AppValueListData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppValueListData(int id, AppValueListData appValueListData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appValueListData.AppValueListId)
            {
                return BadRequest();
            }

            db.Entry(appValueListData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppValueListDataExists(id))
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

        // POST: api/AppValueListData
        [ResponseType(typeof(AppValueListData))]
        public IHttpActionResult PostAppValueListData(AppValueListData appValueListData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppValueListDatas.Add(appValueListData);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AppValueListDataExists(appValueListData.AppValueListId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = appValueListData.AppValueListId }, appValueListData);
        }

        // DELETE: api/AppValueListData/5
        [ResponseType(typeof(AppValueListData))]
        public IHttpActionResult DeleteAppValueListData(int id)
        {
            AppValueListData appValueListData = db.AppValueListDatas.Find(id);
            if (appValueListData == null)
            {
                return NotFound();
            }

            db.AppValueListDatas.Remove(appValueListData);
            db.SaveChanges();

            return Ok(appValueListData);
        }

        
          [Route("api/AppValueListData/Vaccines")]
        public IEnumerable<VaccineTypesViewModel> GetVaccineTypes()
        {
            var vaccineTpes = db.VaccinationTypes.ToList();
            var vaccineTypesVM = Mapper.Map<List<VaccinationType>, IEnumerable<VaccineTypesViewModel>>(vaccineTpes);
            return vaccineTypesVM;

        }
        [Route("api/AppValueListData/Samples")]
        public IEnumerable<SampleTypeViewModel>GetSampleTypes ()
        {
            var sampleTypes = db.SampleTypes.ToList();
            var sampleTypesVM = Mapper.Map<List<SampleType>, IEnumerable<SampleTypeViewModel>>(sampleTypes);
            return sampleTypesVM;

        }
        [Route("api/AppValueListData/Questionnaires")]
        public IEnumerable<QuestionnaireTypeViewModel> GetQuestionnaireTypes()
        {
            var questionType = db.QuestionnaireTypes.ToList();
            var questionTypeVM = Mapper.Map<List<QuestionnaireType>, IEnumerable<QuestionnaireTypeViewModel>>(questionType);
            return questionTypeVM;

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppValueListDataExists(int id)
        {
            return db.AppValueListDatas.Count(e => e.AppValueListId == id) > 0;
        }
    }
}