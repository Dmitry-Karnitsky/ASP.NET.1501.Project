using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Login")]
        public string Name { get; set; }

        [Display(Name = "Date of registration")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Email")]
        public string E_mail { get; set; }    

        [Display(Name = "Role")]
        public string Role { get; set; }
    }

}