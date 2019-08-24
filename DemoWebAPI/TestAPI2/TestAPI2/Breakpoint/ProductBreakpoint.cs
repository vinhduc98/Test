using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI2.Breakpoint
{
    public class ProductBreakpoint
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual int category_id { get; set; }
    }
}