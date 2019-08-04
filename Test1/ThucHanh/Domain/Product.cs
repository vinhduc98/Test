using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh.Domain
{
    public class Product         
    {
        public virtual int Id { get; set; }
        public virtual string name { get; set; }
        public virtual string loai { get; set; }
        public virtual string xuatxu { get; set; }
        public virtual double gia { get; set; }
        public virtual string ghichu { get; set; }
        public virtual int soluong { get; set; }
        public virtual int so8 { get; set; }
        public virtual int so9 { get; set; }
        public virtual int so10 { get; set; } 
    }
}
