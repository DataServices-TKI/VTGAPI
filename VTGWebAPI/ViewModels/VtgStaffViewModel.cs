using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class VtgStaffViewModel
    {

        public int VtgStaffId { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string MiddleInitials { get; set; }
        public string Username { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string VtgStaffLocation { get; set; }
        public string Details { get; set; }
        public string DbaseRole { get; set; }
        public string Password { get; set; }
        public int? CurrentStudy { get; set; }
        public DateTime? EffFrom { get; set; }
        public DateTime? EffTo { get; set; }
        public bool? DeletePrivilege { get; set; }
    }
}