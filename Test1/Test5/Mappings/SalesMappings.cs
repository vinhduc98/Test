using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test5.Domain;

namespace Test5.Mappings
{
    public class SalesMappings:ClassMap<Sales>
    {
        public SalesMappings()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Salesperson);
            Map(x => x.Area);
            Map(x => x.so1);
            Map(x => x.so2);
            Map(x => x.so3);
            Map(x => x.so4);
            Map(x => x.so5);
            Map(x => x.so6);
            Map(x => x.Value);
            Table("Sales");
        }
    }
}
