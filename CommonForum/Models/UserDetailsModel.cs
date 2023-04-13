using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonForum.Models
{
    public class UserDetailsModel
    {
        public int SRNO { get; set; }
        public Guid USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public int ROLE_ID { get; set; }
        public string EMAIL_ID { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ADDED_BY_DATETIME { get; set; }
    }
}