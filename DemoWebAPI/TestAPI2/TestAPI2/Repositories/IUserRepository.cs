using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI2.Models;

namespace TestAPI2.Repositories
{
    public interface IUserRepository
    {
        User getUser(string UserName, string PassWord);
    }
}
