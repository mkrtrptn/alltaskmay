using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace smloginregistration.Models
{
    public class UserLogin
    {
        [Display(Name ="User Name")]
        [Required(ErrorMessage ="Enter Username !")]
        public string username { get; set; }
        [Display(Name ="Password")]
        [Required(ErrorMessage ="Enter Password")]
        public string password { get; set; }
    }
}