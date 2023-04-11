using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommonForum.Models
{
    public class Signup
    {
        [Required]
        [Display(Name = "Display Name")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public Guid USER_GUID { get; set; }
        public Guid ActivationCode { get; set; }
    }
}