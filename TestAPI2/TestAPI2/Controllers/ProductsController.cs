using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAPI2.Breakpoint;
using TestAPI2.Models;
using TestAPI2.Repositories;

namespace TestAPI2.Controllers
{
    [RoutePrefix("api")]
    public class ProductsController : ApiController
    {
        IProductRepository rp = new ProductRepository();

        [Route("Products")]
        [HttpGet]//Lay het danh sach product
        public IEnumerable<ProductBreakpoint> GetAllProduct()
        {
            return rp.getAllPB();
        }

        [Route("Products")]
        [HttpGet]//Lay product theo Id
        public IHttpActionResult GetProductById(int id)
        {
            try
            {
                var pd = rp.getProductByIdBP(id);
                return Ok(pd);
            }
            catch 
            {
                return NotFound();
            }
        }

        [Route("Products")]
        [HttpPost]//Tao moi 1 product
        public HttpResponseMessage PostProduct(Product p)
        {
            try
            {
                rp.Create(p);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, e.Message);
            }  
                        
        }

        [Route("Products")]
        [HttpPut]//Update 1 product
        public HttpResponseMessage PutProduct([FromBody]Product p)
        {
            try
            {
                Product pd = new Product()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    category_Id = p.category_Id
                };
                rp.update(pd);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, e.Message);
            }           
        }

        [Route("Products")]
        [HttpDelete]//Xoa 1 product
        public HttpResponseMessage DeleteProduct(int id)
        {
            try
            {
                rp.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, e.Message);
            }
        }
    }
}
