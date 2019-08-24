using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAPI2.Models;
using TestAPI2.Repositories;

namespace TestAPI2.Controllers
{
    public class UsersController : ApiController
    {
        IUserRepository rp = new UserRepository();
        [HttpGet]

        public User Get(string username, string password)
        {
            return rp.getUser(username, password);
        }
    }
}
