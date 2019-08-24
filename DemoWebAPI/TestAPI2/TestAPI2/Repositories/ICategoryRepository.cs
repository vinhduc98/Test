using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI2.Breakpoint;
using TestAPI2.Models;

namespace TestAPI2.Repositories
{
    public interface ICategoryRepository
    {
        //Lay tat ca danh sach category 
        IEnumerable<Category> getAll();      
        //mode category de hien thi
        IEnumerable<CategoryBreakpoint> getAllBP();
        //Lay Category theo Id
        Category getCategoryById(int id);
        //mode category de hien thi theo id
        CategoryBreakpoint getCategoryByIdBp(int id);
        //Tao moi 1 category
        void Create(Category c);
        //Xoa 1 category theo id
        void Delete(int id );
        //Update category
        void Update(Category c);
        //Lay danh sach product theo category
        IEnumerable<Product> getPDByIdCT(int id_category);
        //mode product de hien thi theo id_category
        IEnumerable<ProductBreakpoint> getPDByIdCTBP(int id_category);
    }
}
