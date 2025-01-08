using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManageInventryShipmentAPI.DAL;
using ManageInventryShipmentAPI.BAL;
using static System.Net.WebRequestMethods;
using System.Resources;
using ManageInventryShipmentAPI.Data;
using System.Reflection.Metadata;
using System;

namespace ManageInventryShipmentAPI.Controllers

{   /// <summary>   
    /// controller handles HTTP requests and responses. This makes the code more maintainable and testable
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       
        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;

        /// <summary>
        /// Constructor Injection: The constructor injects dependencies like IProductService and ILogger<ProductController>. 
        /// This allows the controller to interact with the product service and log errors or other information.
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="logger"></param>
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            // Use 'this' to refer to the class-level field ,the productService on the right-hand side
            // is the parameter passed into the constructor and it gets assigned to the class field.
            this.productService = productService;  
            this.logger = logger; 
        }

        /// <summary>
        /// [HttpGet]: This attribute defines that this method should handle HTTP GET requests. 
        /// This method is asynchronous and returns a Task<IActionResult>. This allows you to perform asynchronous operations (like fetching data from a database) without blocking the thread.
        /// </summary>
        /// <returns>The return type IActionResult allows flexibility in returning different HTTP status codes, along with data or error messages.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await productService.GetAllProductsAsync();
                if (products == null)
                    return NotFound();

                return Ok(products);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving all products.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// [HttpGet]: This attribute defines that this method should handle HTTP GET requests. 
        /// This method is asynchronous and returns a Task<IActionResult>. This allows you to perform asynchronous operations (like fetching data from a database) without blocking the thread.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The return type IActionResult allows flexibility in returning different HTTP status codes, along with data or error messages.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error retrieving product with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// [HttpPost]: This attribute signifies that the method will handle HTTP POST requests, 
        /// which are typically used for creating or adding resources.
        /// This method is asynchronous and returns a Task<IActionResult>. This allows you to perform asynchronous operations (like fetching data from a database) without blocking the thread.
        /// </summary>
        /// <param name="product">it expects a Product object in the request body</param>
        /// <returns>The return type IActionResult allows flexibility in returning different HTTP status codes, along with data or error messages.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product is null");
                }

                await productService.AddProductAsync(product);
                //The product is returned in the response body, representing the newly created resource.
                //CreatedAtAction generates a 201-Created response status code along with the newly created resource
                return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding product.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// This is used for update purpose. 
        /// </summary>
        /// <param name="id">it expects a Product-Id in the request body</param>
        /// <param name="product">it expects a Product object in the request body</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            try
            {
                if (id != product.ProductId)
                {
                    return BadRequest("Product ID mismatch");
                }

                await productService.UpdateProductAsync(product);
                //The product is returned in the response body, representing the updated resource.
                //CreatedAtAction generates a 201-updated response status code along with the updated resource
                return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating product.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// [HttpDelete("{id}"):This attribute tells ASP.NET Core that this method should handle HTTP DELETE requests, specifically those that include a route parameter (id).
        /// The { id} in the route template indicates that the id of the product to be deleted will be passed as part of the URL.For example, a request to /api/products/5 will pass 5 as the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await productService.DeleteProductAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error deleting product.");
                return StatusCode(500, "Internal server error");
            }
        }
    }

}

