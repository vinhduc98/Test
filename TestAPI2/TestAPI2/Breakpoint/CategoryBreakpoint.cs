using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI2.Breakpoint
{
    public class CategoryBreakpoint
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IEnumerable<ProductBreakpoint> products { get; set; }

    }
}