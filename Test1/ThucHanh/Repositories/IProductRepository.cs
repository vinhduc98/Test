using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ThucHanh.Domain;

namespace ThucHanh.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        void GetbyId(int key);
        void Update(int key);
        void Update1(int key);
        void Delete(int key);
        IList<Product> GetAll();
        //IList<Product> Where(Expression<Func<Product, bool>> where)  ;
        IList<Product> Where(Expression<Func<Product, bool>> condition);
        IList<int> GetId();
        bool Kiemtra(int i);
        Expression<Func<Product, bool>> CheckId(int key);
        ICollection<Product> GetByLoai(string loai);
    }
}
