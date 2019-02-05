﻿using System;
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
    public class VtgStaffsController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/VtgStaffs
        public IEnumerable<VtgStaff> GetVtgStaffs()
        {
            return db.VtgStaffs;
        }

        [HttpGet]     
        [Route ("api/VtgStaffs/AuthenticateUser")]   
        [ActionName("AuthenticateUser")]
        public bool AuthenticateUser(string username, string password)
        {
            var user=db.VtgStaffs.Where(s=>s.Username==username & s.Password==password).FirstOrDefault();
            if (user != null)
            {
                return true;
                
            }
            
            else
            {
                return false;
            }
        }

        // GET: api/VtgStaffs/5

        public UserViewModel GetVtgStaff(int id)
        {
            var user=new UserViewModel();
            var mapper = new UserMapper();
            VtgStaff vtgStaff = db.VtgStaffs.Find(id);
            user = mapper.GetuserViewModel(vtgStaff);
            return user;
        }

        // PUT: api/VtgStaffs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVtgStaff(int id, VtgStaff vtgStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vtgStaff.VtgStaffId)
            {
                return BadRequest();
            }

            db.Entry(vtgStaff).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VtgStaffExists(id))
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

        // POST: api/VtgStaffs
     
        public IHttpActionResult PostVtgStaff(VtgStaff vtgStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VtgStaffs.Add(vtgStaff);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vtgStaff.VtgStaffId }, vtgStaff);
        }

        

        // DELETE: api/VtgStaffs/5
        [ResponseType(typeof(VtgStaff))]
        public IHttpActionResult DeleteVtgStaff(int id)
        {
            VtgStaff vtgStaff = db.VtgStaffs.Find(id);
            if (vtgStaff == null)
            {
                return NotFound();
            }

            db.VtgStaffs.Remove(vtgStaff);
            db.SaveChanges();

            return Ok(vtgStaff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VtgStaffExists(int id)
        {
            return db.VtgStaffs.Count(e => e.VtgStaffId == id) > 0;
        }
    }
}