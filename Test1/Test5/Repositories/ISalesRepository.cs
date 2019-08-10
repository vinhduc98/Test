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
        int findID(int[] a, int value);
        //Xoá sử dụng T-SQL
        void Delete();
        //Lấy danh sách theo Id sử dụng HQL
        IList<Sales> GetListbyId(int key);
        IList<Sales> GetAll();
        void Update(int key);
        void Delete(int key);
        //Tạo 1 danh sách Object de them vao
        IEnumerable<Sales> CreateObjectAdd(int count);
        //Tao 1 danh sách Object de xoa
        //insert theo so luong record
        void Add(int amount);
        //insert theo so luon record su dung stateless
        void Add1(int amount);
    }
}
