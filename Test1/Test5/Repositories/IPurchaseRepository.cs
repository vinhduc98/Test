using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test5.Domain;

namespace Test5.Repositories
{
    public interface IPurchaseRepository
    {
        void Add(Purchase p);
        void Update(Purchase p);
        void Delete(Purchase p);
        ICollection<Purchase> GetById(int key);
        IList<Purchase> GetAll();
    }
}
