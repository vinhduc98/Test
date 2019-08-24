using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI2.Models
{
    public class User
    {
        public virtual int UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual string UserPassword { get; set; }
        public virtual string UserRole { get; set; }
        public virtual string UserEmailId { get; set; }
    }
}