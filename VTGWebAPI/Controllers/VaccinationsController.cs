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
    public class VaccinationsController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/Vaccinations
        public IQueryable<Vaccination> GetVaccinations()
        {
            return db.Vaccinations;
        }

        // GET: api/Vaccinations/5
        [ResponseType(typeof(Vaccination))]
        public VaccineViewModel GetVaccination(int id)
        {
            Vaccination vaccination = db.Vaccinations.Find(id);
            if (vaccination == null)
            {
                return null;
            }
            var vaccineVM = Mapper.Map<Vaccination, VaccineViewModel>(vaccination);

            return vaccineVM;
        }

        // PUT: api/Vaccinations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVaccination(int id, Vaccination vaccination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vaccination.VaccinationId)
            {
                return BadRequest();
            }
            vaccination.Description = db.VaccinationTypes.Find(vaccination.TypeVaccinationId).Description;
            db.Entry(vaccination).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccinationExists(id))
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

        // POST: api/Vaccinations
        [ResponseType(typeof(Vaccination))]
        public IHttpActionResult PostVaccination(Vaccination vaccination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vaccination.Description = db.VaccinationTypes.Find(vaccination.TypeVaccinationId).Description;
            db.Vaccinations.Add(vaccination);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vaccination.VaccinationId }, vaccination);
        }

        // DELETE: api/Vaccinations/5
        [ResponseType(typeof(Vaccination))]
        public IHttpActionResult DeleteVaccination(int id)
        {
            Vaccination vaccination = db.Vaccinations.Find(id);
            if (vaccination == null)
            {
                return NotFound();
            }

            db.Vaccinations.Remove(vaccination);
            db.SaveChanges();

            return Ok(vaccination);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VaccinationExists(int id)
        {
            return db.Vaccinations.Count(e => e.VaccinationId == id) > 0;
        }
    }
}