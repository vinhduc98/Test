using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucHanh.Domain;

namespace ThucHanh.Mappings
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.name);
            Map(x => x.loai);
            Map(x => x.xuatxu);
            Map(x => x.gia);
            Map(x => x.ghichu);
            Map(x => x.soluong);
            Map(x => x.so8);
            Map(x => x.so9);
            Map(x => x.so10);
            Table("Product");
        }
    }
}
