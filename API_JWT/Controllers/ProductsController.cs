using API_JWT.Models;
using API_JWT.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API_JWT.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            Response response = new Response();
            try
            {
                using (var db = new PruebaJWTContext())
                {
                    var products = db.Products.ToList();
                    response.Success = 1;
                    response.Data = products;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
            
        }

        [HttpPost]
        public IActionResult CreateProducts()
        {
            Response response = new Response();
            try
            {
                using (var db = new PruebaJWTContext())
                {
                    var products = db.Products.ToList();
                    response.Success = 1;
                    response.Data = products;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);

        }
    }
}
