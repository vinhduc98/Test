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
            IEnumerable<ProductBreakpoint> products = listproduct.Select(p => new ProductBreakpoint()
            {
                Id = p.Id,
                Name=p.Name,
                Price=p.Price,
                category_id=p.category_Id         
            });
            return products;
        }

        public Product getProductById(int id)
        {
            return session.Get<Product>(id);
        }

        public ProductBreakpoint getProductByIdBP(int id)
        {
            var pd = getProductById(id);
            ProductBreakpoint product = new ProductBreakpoint()
            {
                Id=pd.Id,
                Name=pd.Name,
                Price=pd.Price,
                category_id=pd.category_Id
            };
            return product;
               
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