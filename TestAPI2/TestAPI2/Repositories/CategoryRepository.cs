using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAPI2.Breakpoint;
using TestAPI2.Models;

namespace TestAPI2.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ISession session = FluentNHibernatehelper.GetSession();

        public void Create(Category c)
        {
            ITransaction tran = session.BeginTransaction();
            session.Save(c);
            tran.Commit();
            session.Close();
        }

        public void Delete(int id)
        {
            var ct= getCategoryById(id);
            session.Delete(ct);
            session.Flush();
        }

        public IEnumerable<Category> getAll()
        {
            return session.CreateCriteria(typeof(Category)).List<Category>();
        }

        public IEnumerable<CategoryBreakpoint> getAllBP()
        {
            var listcategory = getAll();
            IEnumerable<CategoryBreakpoint> categories = listcategory.Select(c => new CategoryBreakpoint()
            {
                Id = c.Id,
                Name = c.Name,
                products = c.products.Select(p => new ProductBreakpoint()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    category_id = p.category_Id
                })
            });
            return categories;
        }
       
        public Category getCategoryById(int id)
        {
            var category= session.Get<Category>(id);
            return category;
        }

        public CategoryBreakpoint getCategoryByIdBp(int id)
        {
            var category = getCategoryById(id);
            CategoryBreakpoint ct = new CategoryBreakpoint()
            {
                Id = category.Id,
                Name = category.Name,
                products= category.products.Select(p=>new ProductBreakpoint()
                {
                    Id=p.Id,
                    Name=p.Name,
                    Price=p.Price,
                    category_id=p.category_Id
                })
             
            };
            return ct;
        }

        public IEnumerable<Product> getPDByIdCT(int id_category)
        {
            return session.CreateCriteria(typeof(Product)).Add(Restrictions.Eq("category.Id", id_category)).List<Product>();
        }

        public IEnumerable<ProductBreakpoint> getPDByIdCTBP(int id_category)
        {
            var pds=getPDByIdCT(id_category);
            return ConvertList(pds);
        }


        //Covert list Product sang ProducBreakpoint
        public IEnumerable<ProductBreakpoint> ConvertList(IEnumerable<Product> p)
        {
            var list = p.Select(x => new ProductBreakpoint()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                category_id = x.category_Id
            });
            return list;
        }


        public void Update(Category c)
        {
            ITransaction tran= session.BeginTransaction();
            session.Update(c);
            tran.Commit();
            session.Close();
        }        
       
    }
}