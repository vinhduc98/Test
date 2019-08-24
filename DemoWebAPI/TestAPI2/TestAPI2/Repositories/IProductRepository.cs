using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI2.Breakpoint;
using TestAPI2.Models;

namespace TestAPI2.Repositories
{
    public interface IProductRepository
    {
        //Lay tat ca product
        IEnumerable<Product> getAll();      
        //Mode product de hien thi 
        IEnumerable<ProductBreakpoint> getAllPB();
        //Lay product theo id
        Product getProductById(int id);
        //Mode product de hien thi theo id
        ProductBreakpoint getProductByIdBP(int id);
        //Tao moi 1 product
        void Create(Product p);
        //cap nhat 1 product
        void update(Product p);
        //Xoa 1 product theo Id
        void Delete(int id);
    }
}
