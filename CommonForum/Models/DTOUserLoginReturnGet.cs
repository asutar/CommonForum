using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonForum.Models
{
    public class DTOUserLoginReturnGet
    {
        public int ReturnValue { get; set; } // string, not null
        public string CLIENT_NAME { get; set; } // string, not null
    }
}