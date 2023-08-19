using CatalogAPI.DTOs;
using CatalogAPI.Services.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Agora criar RefreshToken os Dtos de User, RefreshToken e criar o repositorio...
        // Para criação do Token!!


        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("id", Name = "GetProducts")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var product = await _productService.GetById(id);
            if (product is null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _productService.Add(productDto);
            return new CreatedAtRouteResult("GetProducts", new { id = productDto.Id }, productDto);
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id)
                return BadRequest();
            await _productService.Update(productDTO);
            return Ok(productDTO);
        }


        [HttpDelete("id")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var productDto = await _productService.GetById(id);
            if (productDto is null)
                return NotFound();
            await _productService.Delete(id);
            return Ok(productDto);
        }

    }
}
