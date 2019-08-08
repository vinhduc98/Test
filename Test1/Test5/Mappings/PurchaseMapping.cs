using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test5.Domain;

namespace Test5.Mappings
{
    public class PurchaseMapping:ClassMap<Purchase>
    {
        public PurchaseMapping()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.purchaseperson);
            Map(x => x.Area);
            Table("Purchase");
        }
    }
}
