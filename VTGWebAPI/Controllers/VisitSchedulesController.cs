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
        [ResponseType(typeof(VisitSchedule))]
        public VisitScheduleViewModel GetVisitSchedule(int id)
        {
            var visitSchedule = db.VisitSchedules.Find(id);
            var visitScheduleViewModel = Mapper.Map<VisitSchedule, VisitScheduleViewModel>(visitSchedule);
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