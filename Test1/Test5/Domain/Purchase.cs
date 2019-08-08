using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test5.Domain
{
    public class Purchase
    {
        public virtual int Id { get; set; }
        public virtual string purchaseperson { get; set; }
        public virtual string Area { get; set; }
    }
}
