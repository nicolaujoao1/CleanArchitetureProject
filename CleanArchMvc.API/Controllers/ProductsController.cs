using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products=await _productService.GetProducts();
            if(products is null)
                return NotFound("There´s no product");  
            return Ok(products);
        }
       
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _productService.GetById(id);
            if (product is null)
                return NotFound("Not found");
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO is null)
                return BadRequest();
            await _productService.Add(productDTO);
            return new CreatedAtRouteResult(nameof(GetProduct), new {id=productDTO.Id},productDTO);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id)
                return BadRequest();
            if (productDTO is null)
                return BadRequest();
            await _productService.Update(productDTO);
            return Ok(productDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetById(id);
            if (product is null)
                return BadRequest();
            await _productService.Remove(id);
            return Ok(product);
        }
    }
}
