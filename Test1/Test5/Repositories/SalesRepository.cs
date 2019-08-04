using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test5.Domain;

namespace Test5.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        public void Add(Sales s)
        {
            using (var session = FluentNHibernateHleper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    //try
                    //{
                        session.Save(s);
                        transaction.Commit();
                        session.Close();
                    //}
                    //catch (Exception)
                    //{
                    //    transaction.Rollback();
                    //}
                }
            }
        }

        public void Delete(Sales s)
        {
            using (var session = FluentNHibernateHleper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(s);
                        transaction.Commit();
                        session.Close();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public void Update(Sales s)
        {
            using (var session = FluentNHibernateHleper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(s);
                        transaction.Commit();
                        session.Close();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public ICollection<Sales> GetById(int key)
        {
            using (var session = FluentNHibernateHleper.OpenSession())
            {
                var a = session.CreateCriteria(typeof(Sales)).Add(Restrictions.Eq("Id", key)).List<Sales>();
                return a;
            }
        }

        public IList<Sales> Where(Expression<Func<Sales, bool>> con)
        {
            
            using (var session = FluentNHibernateHleper.OpenSession())
            {
                return session.Query<Sales>().Where(con).ToList();
            }
        }

        public int[] GetId()
        {
            using (var session = FluentNHibernateHleper.OpenSession())
            {

                int[] id_s = session.Query<Sales>().Select(c => c.Id).ToArray();
                return id_s;
            }
        }

        public int Tryfind(int[] a, int value)
        {
            int First = 0;
            int Last = a.Length - 1;
            while (First <= Last)
            {
                int MID = (First + Last) / 2;
                if (a[MID] == value)  //Tim thay
                    return MID;
                else if (value < a[MID])
                    Last = MID - 1;
                else
                    First = MID + 1;
            }
            //Ko tim duoc gi
            return -1;
        }
        public void Update(int key)
        {
            using (var session = FluentNHibernateHleper.OpenSession())
            using (ITransaction tran = session.BeginTransaction())
            {
                var query = session.CreateQuery("Update Sales set salesperson='yasuo' Where Id='" + key + "'")
                        .ExecuteUpdate();
                tran.Commit();
                session.Close();
            }
        }
        public void Delete(int key)
        {
            using (var session = FluentNHibernateHleper.OpenSession())
            using (ITransaction tran = session.BeginTransaction())
            {
                var query = session.CreateQuery("Delete From Sales Where Id='" + key + "'")
                                            .ExecuteUpdate();
                tran.Commit();
                session.Close();
            }
        }

        public void Delete()
        {
           
            using (var session = FluentNHibernateHleper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var query = session.CreateSQLQuery("SELECT 1 WHILE @@ROWCOUNT > 0" +
                                                        " BEGIN DELETE TOP(10000) FROM Sales " +
                                                        "END").ExecuteUpdate();                                     
                transaction.Commit();
                session.Close();
            }         
        }

    }
}
