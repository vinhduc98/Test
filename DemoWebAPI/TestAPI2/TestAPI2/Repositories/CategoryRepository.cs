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
        ExtraRepository allrp = new ExtraRepository();

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
            return allrp.ConvertListCT(listcategory);
        }
       
        public Category getCategoryById(int id)
        {
            var category= session.Get<Category>(id);
            return category;
        }

        public CategoryBreakpoint getCategoryByIdBp(int id)
        {
            var category = getCategoryById(id);          
            return allrp.ConvertCT(category);
        }

        public IEnumerable<Product> getPDByIdCT(int id_category)
        {
            return session.CreateCriteria(typeof(Product)).Add(Restrictions.Eq("category.Id", id_category)).List<Product>();
        }

        public IEnumerable<ProductBreakpoint> getPDByIdCTBP(int id_category)
        {
            var pds=getPDByIdCT(id_category);
            return allrp.ConvertListPD(pds);
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