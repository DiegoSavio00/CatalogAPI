using CatalogAPI.Domain.Entities;
using CatalogAPI.DTOs;
using CatalogAPI.Services.InterfaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            try
            {
                var categories = await _categoryService.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("id", Name = "GetCategory")]
        public async Task<ActionResult<Category>> GetId(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category is null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _categoryService.Add(categoryDTO);
            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != categoryDTO.Id)
                return BadRequest();
            await _categoryService.Update(categoryDTO);
            return Ok(categoryDTO);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category is null)
                return NotFound();
            await _categoryService.Delete(id);
            return Ok(category);
        }

    }
}
