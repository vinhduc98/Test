using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI2.Models
{
    public class Category
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Product> products { get; set; }

        public Category()
        {
            products = new List<Product>();
        }
    }
}