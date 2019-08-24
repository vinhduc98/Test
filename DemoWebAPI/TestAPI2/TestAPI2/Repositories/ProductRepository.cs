using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAPI2.Breakpoint;
using TestAPI2.Models;

namespace TestAPI2.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ISession session = FluentNHibernatehelper.GetSession();
        ExtraRepository allrp = new ExtraRepository();

        public void Create(Product p)
        {
            ITransaction tran = session.BeginTransaction();
            session.Save(p);
            tran.Commit();
        }

        public void Delete(int id)
        {
            var product= session.Get<Product>(id);
            session.Delete(product);
            session.Flush();
        }

        public IEnumerable<Product> getAll()
        {
            return session.CreateCriteria(typeof(Product)).List<Product>();
        }

        public IEnumerable<ProductBreakpoint> getAllPB()
        {
            var listproduct= getAll();          
            return allrp.ConvertListPD(listproduct);
        }

        public Product getProductById(int id)
        {
            return session.Get<Product>(id);
        }

        public ProductBreakpoint getProductByIdBP(int id)
        {
            var pd = getProductById(id);            
            return allrp.ConvertPD(pd);
               
        }

        public void update(Product p)
        {
            ITransaction tran = session.BeginTransaction();
            session.Update(p);
            tran.Commit();
            session.Close();
        }
    }
}