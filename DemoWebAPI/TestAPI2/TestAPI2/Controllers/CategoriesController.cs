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
    public class CategoriesController : ApiController
    {
        ICategoryRepository rp = new CategoryRepository();

        [Authorize(Roles = "Admin")]
        [Route("Categories")]// api/categories       
        [HttpGet]//lay danh sach category
        public IEnumerable<CategoryBreakpoint> GetAllCt()
        {
            return rp.getAllBP();
        }
        
        [Route("Categories")]// api/categories?Id={Id}
        [HttpGet]//Lay category theo id
        public IHttpActionResult GetCtById(int id)
        {          
            try
            {
                var ct=rp.getCategoryByIdBp(id);
                return Ok(ct);
            }
            catch 
            {               
                return NotFound();
            }
           
        }

        [Route("Categories")]// api/categories
        [HttpPost]//Tao moi 1 category - xy ly o body
        public HttpResponseMessage PostCategory([FromBody]Category c)
        {
            try
            {
                rp.Create(c);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, e.Message);
            }
        }

        [Route("Categories")]// api/categories?Id={Id}
        [HttpDelete]//Xoa 1 category theo Id
        public HttpResponseMessage DeleteCategory(int id)
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

        [Route("Categories")]// api/categories
        [HttpPut]//Cap nhat 1 category
        public HttpResponseMessage UpdateCategory(Category c)
        {
            try
            {              
                rp.Update(c);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, e.Message);
            }
        }

        [Route("Categories/Products")]// api/categories/product?categories_id={categories_id}
        [HttpGet]//Goi ham lay produc theo id cua category
        public IHttpActionResult GetProductById_Category(int category_id)
        {
            try
            {
                var pds = rp.getPDByIdCTBP(category_id);
                return Ok(pds);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
