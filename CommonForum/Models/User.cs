using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonForum.Models
{
    public class User
    {
        public int USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string EMAIL_ID { get; set; }
        public int FLAG { get; set; }
    }
}