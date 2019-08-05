using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test5.Domain;

namespace Test5.Repositories
{
    interface ISalesRepository
    {
        void Add(Sales s);
        void Update(Sales s);
        void Delete(Sales s);
        //Lấy danh sách Sales theo Id
        ICollection<Sales> GetById(int key);
        //Lấy danh sách Sales theo Id
        IList<Sales> Where(Expression<Func<Sales, bool>> condition);
        //Lấy 1 mảng Id
        int[] GetId();
        /// <summary>
        /// Hàm tìm Id
        /// </summary>
        /// <param name="a"></param> mảng Id
        /// <param name="value"></param> Giá trị id cần tìm
        /// <returns></returns>
        int Tryfind(int[] a, int value);
        //Xoá sử dụng T-SQL
        void Delete();
        //Lấy danh sách theo Id sử dụng HQL
        IList<Sales> GetListbyId(int key);
        void Update(int key);
        void Delete(int key);
    }
}
