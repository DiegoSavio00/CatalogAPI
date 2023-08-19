using CatalogAPI.DTOs;

namespace CatalogAPI.Services.InterfaceService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetById(int id);
        Task Add(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Delete(int id);
    }
}
