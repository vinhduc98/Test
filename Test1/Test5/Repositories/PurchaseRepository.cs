using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test5.Domain;

namespace Test5.Repositories
{
    public class PurchaseRepository:IPurchaseRepository
    {
        public void Add(Purchase p)
        {
            using (var session = FluentNHibernateHleper.statelessSession())
            using (ITransaction tran = session.BeginTransaction())
            {
                try
                {
                    session.Insert(p);
                    tran.Commit();
                }
                catch (Exception)
                {

                    tran.Rollback();
                }
                finally
                {
                    session.Close();
                }
            }
        }
        public void Update(Purchase p)
        {
            using (var session = FluentNHibernateHleper.statelessSession())
            using (ITransaction tran = session.BeginTransaction())
            {
                try
                {
                    session.Update(p);
                    tran.Commit();
                }
                catch (Exception)
                {

                    tran.Rollback();
                }
                finally
                {
                    session.Close();
                }
            }
        }
        public void Delete(Purchase p)
        {
            using (var session = FluentNHibernateHleper.statelessSession())
            using (ITransaction tran = session.BeginTransaction())
            {
                try
                {
                    session.Delete(p);
                    tran.Commit();
                }
                catch (Exception)
                {

                    tran.Rollback();
                }
                finally
                {
                    session.Close();
                }
            }
        }

        public ICollection<Purchase> GetById(int key)
        {
            using (var session = FluentNHibernateHleper.statelessSession())
            {
                var a = session.CreateCriteria(typeof(Purchase)).Add(Restrictions.Eq("Id", key)).List<Purchase>();
                return a;
            }
        }

        public IList<Purchase> GetAll()
        {
            using (var session = FluentNHibernateHleper.statelessSession())
            {
                var all = session.Query<Purchase>().ToList();
                return all;
            }
        }
    }
}
