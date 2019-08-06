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
            using (var session = FluentNHibernateHleper.GetSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {                    
                    session.Insert(s);
                    transaction.Commit();
                }
                finally
                {
                    session.Close();
                }
            }
        }

        public void Delete(Sales s)
        {
            using (var session = FluentNHibernateHleper.GetSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(s);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                    finally
                    {
                        session.Close();
                    }
                }
            }
        }

        public void Update(Sales s)
        {
            using (var session = FluentNHibernateHleper.GetSession())
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
                    finally
                    {
                        session.Close();
                    }
                }
            }
        }

        public ICollection<Sales> GetById(int key)
        {
            using (var session = FluentNHibernateHleper.GetSession())
            {
                var a = session.CreateCriteria(typeof(Sales)).Add(Restrictions.Eq("Id", key)).List<Sales>();
                return a;
            }
        }

        public IList<Sales> Where(Expression<Func<Sales, bool>> con)
        {
            
            using (var session = FluentNHibernateHleper.GetSession())
            {
                return session.Query<Sales>().Where(con).ToList();
            }
        }

        public int[] GetId()
        {
            using (var session = FluentNHibernateHleper.GetSession())
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
            using (var session = FluentNHibernateHleper.GetSession())
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
            using (var session = FluentNHibernateHleper.GetSession())
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
           
            using (var session = FluentNHibernateHleper.GetSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var query = session.CreateSQLQuery("SELECT 1 WHILE @@ROWCOUNT > 0" +
                                                        " BEGIN DELETE TOP(10000) FROM Sales " +
                                                        "END").ExecuteUpdate();                                     
                transaction.Commit();
                session.Close();
            }         
        }

        public IList<Sales> GetListbyId(int key)
        {
            using (var session = FluentNHibernateHleper.GetSession())
            {
                var query = session.CreateQuery("FROM Sales Where Id='"+key+"'");
                IList<Sales> listsales = query.List<Sales>();
                return listsales;
            }
        }
        public IEnumerable<Sales> CreateTestObjects(int count)
        {
            List<Sales> ob = new List<Sales>(count);
            for(int i=0;i<count;i++)
            {
                ob.Add(new Sales { Id=i+1,Salesperson="KV: "+i,so1=1000,so2=20000});
            }
            return ob;
        }
    }
}
