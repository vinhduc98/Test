using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAPI2.Models;

namespace TestAPI2.Mappings
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Product");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Price).Not.Nullable();
            Map(x => x.category_Id).Not.Nullable();
            References(x => x.category).
                Column("category_id").
                Not.Insert().
                Not.Update();
        }
    }
}