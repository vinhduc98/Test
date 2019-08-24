using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAPI2.Models;

namespace TestAPI2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ISession session = FluentNHibernatehelper.GetSession();
        public User getUser(string UserName, string PassWord)
        {
            return session.QueryOver<User>().Where(x=>x.UserName==UserName).And(x=>x.UserPassword==PassWord).SingleOrDefault();
        }
    }
}