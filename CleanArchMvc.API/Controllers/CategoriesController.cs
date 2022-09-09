using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    //[Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService; 
        public CategoriesController(ICategoryService categoryService)=>_categoryService = categoryService;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            if (categories is null) return NotFound("There´s no categories");
            return Ok(categories);
        }
        [HttpGet("{id:int}",Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category=await _categoryService.GetById(id);
            if (category is null) return NotFound("Category not found");
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult>Post([FromBody]CategoryDTO categoryDTO)
        {
            if (categoryDTO is null) return BadRequest("Invalid Data");
            await _categoryService.Add(categoryDTO);
            return new CreatedAtRouteResult(nameof(GetCategory), new {id=categoryDTO.Id},categoryDTO);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id,[FromBody]CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id) return BadRequest("Category no found");
            if (categoryDTO is null) return BadRequest("");
            await _categoryService.Update(categoryDTO);
            return Ok(categoryDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>>Delete(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category is null) return NotFound("Category no found");
            await _categoryService.Remove(id);
            return Ok(category);    
        }
    }
}
