using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAPI2.Breakpoint;
using TestAPI2.Models;

namespace TestAPI2.Repositories
{
    public class ExtraRepository
    {

        //Mode list product sang product breakpoint
        public IEnumerable<ProductBreakpoint> ConvertListPD(IEnumerable<Product> p)
        {
            var list = p.Select(x => new ProductBreakpoint()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                category_id = x.category_Id
            });
            return list;
        }

        //Mode list category sang categorybreakpoint
        public IEnumerable<CategoryBreakpoint> ConvertListCT(IEnumerable<Category> c)
        {
            var list = c.Select(x => new CategoryBreakpoint()
            {
                Id = x.Id,
                Name = x.Name,
                products = ConvertListPD(x.products)
            });
            return list;
        }

        //Mode product sang productbreakpoint
        public ProductBreakpoint ConvertPD(Product p)
        {
            var product = new ProductBreakpoint()
            {
                Id=p.Id,
                Name=p.Name,
                Price=p.Price,
                category_id=p.category_Id
            };
            return product;
        }

        //Mode Category sang categorybreakpoint
        public CategoryBreakpoint ConvertCT(Category c)
        {
            var category = new CategoryBreakpoint()
            {
                Id=c.Id,
                Name=c.Name,
                products=ConvertListPD(c.products)
            };
            return category;
        }
    }
}