using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAPI2.Models;

namespace TestAPI2.Mappings
{
    public class UserMap:ClassMap<User>
    {
        public UserMap()
        {
            Table("User_login");
            Id(x => x.UserId).GeneratedBy.Increment();
            Map(x => x.UserName);
            Map(x => x.UserPassword);
            Map(x => x.UserRole);
            Map(x => x.UserEmailId);          
        }
    }
}