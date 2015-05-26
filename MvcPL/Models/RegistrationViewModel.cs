using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public enum Role
    {
        Admin = 1,
        User,
        Anonim
    }
    public class RegistrationViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
    }
}