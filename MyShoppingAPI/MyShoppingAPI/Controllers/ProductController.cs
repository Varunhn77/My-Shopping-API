using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShoppingEntity;
using MyShoppingService.Services;

namespace MyShoppingAPI.Controllers
{
    [Route("api/[controller]")]  //localhost:3000/api/Product
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }
        [HttpGet("GetProducts")]

        public IActionResult GetAll()
        {
            var result= _productService.GetProducts();
            Response response = null;
            if (result.Count > 0) 
            {
                response = new Response();
                response.statuscode = "200";
                response.result = result;
                response.message = "Success";
                return Ok(response);
            }

                response = new Response();
                response.statuscode = "404";
                response.result = null;
                response.message = "Error";
                return NotFound(response);
        }
        [HttpPost("Create")]

        public IActionResult AddProduct([FromBody] Product product)
        {
            _productService.AddProduct(product);
            //object result = "Product added successfully..";

            Response response = new Response();
            response.statuscode = "200";
            response.result = "Product added Successfully";
            response.message = "Success";

            //var response = new { result };
            return Ok(response);
        }

        [HttpPut("Update")]
        public IActionResult UpdateProduct([FromBody] Product product,int id)
        {
            _productService.UpdateProduct(product);
            Response response = new Response();
            response.statuscode = "200";
            response.result = "Product updated successfully..";
            response.message = "Success";
            //object result = "Product updated successfully..";
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            Response response = new Response();
            response.statuscode = "200";
            response.result = "Product deleted successfully..";
            response.message = "Success";
           // object result = "Product deleted successfully..";
            return Ok(response);
        }

        [HttpGet("GetProductById")]
        public IActionResult GetProductById(int id)
        {
            var result = _productService.GetProductById(id);
            return Ok(result);
        }
    }
    public class Response
    {
        public object result { get; set; }
        public string statuscode { get; set; }
        public string message { get; set; }
    }
}
