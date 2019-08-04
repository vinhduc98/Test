using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ThucHanh.Domain;

namespace ThucHanh.Repositories
{
    public class ProductRepository:IProductRepository
    {
        public void Add(Product product)
        {
            using (var session = FLuentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        Stopwatch st = Stopwatch.StartNew();
                        session.Persist(product);
                        transaction.Commit();
                        st.Stop();
                        session.Close();
                        Console.WriteLine(st.Elapsed + "\t Da insert Vao");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public void Delete(Product product)
        {
            using (var session = FLuentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        Stopwatch st = Stopwatch.StartNew();
                        session.Delete(product);
                        transaction.Commit();
                        session.Close();
                        st.Stop();
                        Console.WriteLine(st.Elapsed + "\t Da xoa");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public void Update(Product product)
        {
            using (var session = FLuentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        Console.WriteLine("update");
                        Stopwatch st = Stopwatch.StartNew();
                        session.Update(product);
                        transaction.Commit();
                        session.Close();
                        st.Stop();
                        Console.WriteLine(st.Elapsed + "\t Da update");
                }
                    catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            }
        }     
        
        public void GetbyId(int key)
        {
            using (var session = FLuentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {                                       
                    var fromDB = session.Get<Product>(key);
                    transaction.Commit();
                    session.Close();           
                }
            }
        }

        public IList<Product> GetAll()
        {
            using (var session = FLuentNHibernateHelper.OpenSession())
            {
                var p= session.CreateCriteria(typeof(Product)).List<Product>();
                return p;
                session.Close();
            }
        }
        public void Update(int key)
        {
            using (var session = FLuentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Stopwatch st = Stopwatch.StartNew();
                    var query = session.CreateQuery("Update Product set name='Update lan dau',soluong=20, loai='Good',gia=50, so8=2,so9=2,so10=2" +
                         " where id='"+key+"'")
                         .ExecuteUpdate();
                    transaction.Commit();
                    session.Close();
                    st.Stop();
                    Console.WriteLine(st.Elapsed+"\t\t\t"+key+"\tUpdate lan dau");
                }
            }
        }

        public void Update1(int key)
        {
            using (var session = FLuentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Stopwatch st = Stopwatch.StartNew();
                    var query= session.CreateQuery("Update Product set name='Update tiep theo',soluong=20, loai='Vip',gia=50, so8=2,so9=2,so10=2" +
                         " where id='" + key + "'")
                         .ExecuteUpdate();
                    transaction.Commit();
                    st.Stop();
                    session.Close();
                    Console.WriteLine(st.Elapsed + "\t\t\t" + key + "\tUpdate tiep theo");
                }
            }
        }
        public void Delete(int key)
        {
            {
                using (var session = FLuentNHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        Stopwatch st = Stopwatch.StartNew();
                        var query = session.CreateQuery("DELETE Product Where Id='"+key+"'")
                             .ExecuteUpdate();
                        transaction.Commit();
                        st.Stop();
                        Console.WriteLine(st.Elapsed);
                        session.Close();
                    }
                }
            }
        }

        //public IList<Product> Where(Expression<Func<Product, bool>>  where)
        //{
        //    using (var session = FLuentNHibernateHelper.OpenSession())
        //    {
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            return session.Query<Product>().Where(c => c.Id==c.Id).ToList();                   
        //        }
        //    }
        //}

        public IList<Product> Where(Expression<Func<Product, bool>> condition) 
        {
            using (var session = FLuentNHibernateHelper.OpenSession())
            {                
               return session.Query<Product>().Where(condition).ToList();               
            }
        }

        public IList<int> GetId()
        {
            using (var session = FLuentNHibernateHelper.OpenSession())
            {
                
                IList<int> id_p = session.Query<Product>().Select(c => c.Id).ToList();
                return id_p;             
            }
        }    

        public bool Kiemtra( int i)
        {
            foreach(var a in GetId())
            {
                if (i == a)
                    return true;
            }
            return false;
        }

        public Expression<Func<Product, bool>> CheckId(int key)
        {
            return p => p.Id == key;
        }

        public ICollection<Product> GetByLoai(string loai)
        {
            using (var session = FLuentNHibernateHelper.OpenSession())
            {               
                var products = session.CreateCriteria(typeof(Product)).Add(Restrictions.Eq("loai", loai)).List<Product>();                         
                return products;               
            }         
        }
    }
}
