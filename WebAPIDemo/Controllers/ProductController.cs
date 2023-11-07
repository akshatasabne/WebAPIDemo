using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Entities;
using WebAPIDemo.Services;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
        // GET: ProductController
        public ProductController(IProductService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("GetProducts")]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.GetProducts());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetProductById/{id}")]
        // GET: ProductController/Details/5
        public IActionResult Get(int id)
        {

            try
            {
                return new ObjectResult(service.GetProductById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
        }
        [HttpPost]
        [Route("AddProduct")]
        // GET: ProductController/Create
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                int result = service.AddProduct(product);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: ProductController/Create
        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult Put([FromBody] Product product)
        {
            try
            {
                int result = service.UpdateProduct(product);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        // GET: ProductController/Edit/5
        public IActionResult Delete(int id)
        {
            try
            {
                int result = service.DeleteProduct(id);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: ProductController/Edit/5
        
        
    }
}
