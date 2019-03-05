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
    public class VtgStaffsController : ApiController
    {
        private VTGEntities db = new VTGEntities();

        // GET: api/VtgStaffs
        public IEnumerable<VtgStaffViewModel> GetVtgStaffs()
        {
            var staff=db.VtgStaffs.ToList();
            var staffVM = Mapper.Map<List<VtgStaff>, IEnumerable<VtgStaffViewModel>>(staff);
            return staffVM;
        }
       

        [HttpGet]
        [Route("api/VtgStaffs/AuthenticateUser")]
        [ActionName("AuthenticateUser")]
        public UserViewModel AuthenticateUser(string username, string password)
        {
            var user = db.VtgStaffs.Where(s => s.Username == username & s.Password == password).FirstOrDefault();
            var mapper = new UserMapper();
            var userViewModel = mapper.GetuserViewModel(user);

            userViewModel.StudyNickName = db.Studies.Where(s => s.StudyId == userViewModel.CurrentStudy).FirstOrDefault().NicknameStudy;
            if (user != null)
                {
                    return userViewModel;
                }
                else
                { 
                    return null;
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
        [Route("api/VtgStaffs/{id}")]
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

        #region VTGStaffRoles
        //GET: api/VtgStaffs/Conatcts
        [Route("api/VtgStaffs/Conatcts")]
        public IEnumerable<StudyRoleViewModel> GetVtgStaffContactRoles()
        {
            var roles = db.StudyRoles.ToList();
            var rolesVM = Mapper.Map<List<StudyRole>, IEnumerable<StudyRoleViewModel>>(roles);
            return rolesVM;
        }

        [Route("api/VtgStaffs/Conatcts/{id}")]
        public LinkVtgStaffStudyViewModel GetVtgStaffRole(int id)
        {
            var vtgStaffRole = db.LinkVtgStaffStudies.Find(id);
            var vtgStaffRoleVM = Mapper.Map<LinkVtgStaffStudy, LinkVtgStaffStudyViewModel>(vtgStaffRole);
            return vtgStaffRoleVM;
        }

        [Route("api/VtgStaffs/Conatcts/{id}")]
        public IHttpActionResult PutStudyRoles(int id, LinkVtgStaffStudyViewModel vtgStaffRoleVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != vtgStaffRoleVM.VtgStaffStudyLinkId)
            {
                return BadRequest();
            }

            var vtgStaffRole = Mapper.Map<LinkVtgStaffStudyViewModel, LinkVtgStaffStudy>(vtgStaffRoleVM);

            db.Entry(vtgStaffRole).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("api/VtgStaffs/Conatcts")]
        public IHttpActionResult PostLinkVtgStaffStudy(LinkVtgStaffStudyViewModel vtgStaffRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vtgStaff = Mapper.Map<LinkVtgStaffStudyViewModel, LinkVtgStaffStudy>(vtgStaffRole);
            db.LinkVtgStaffStudies.Add(vtgStaff);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vtgStaff.VtgStaffId }, vtgStaff);
        }

        [Route("api/VtgStaffs/Conatcts/{id}")]
        public IHttpActionResult DeleteVtgStaffRole(int id)
        {
            var vtgStaffRole = db.LinkVtgStaffStudies.Find(id);
            if (vtgStaffRole == null)
            {
                return NotFound();
            }

            db.LinkVtgStaffStudies.Remove(vtgStaffRole);
            db.SaveChanges();

            return Ok(vtgStaffRole);
        }
        
        #endregion
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