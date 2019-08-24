using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI2.Models
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual int category_Id { get; set; }
        public virtual Category category { get; set; }
    }
}