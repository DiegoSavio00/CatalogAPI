using AutoMapper;
using CatalogAPI.Domain.Entities;
using CatalogAPI.DTOs;
using CatalogAPI.Repositories.Interfaces;
using CatalogAPI.Services.InterfaceService;

namespace CatalogAPI.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepo.CreateAsync(productEntity);
        }

        public async Task Delete(int id)
        {
            var productEntity = _productRepo.GetByIdAsync(id).Result;
            await _productRepo.DeleteAsync(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var productEntity = await _productRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productEntity = await _productRepo.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepo.UpdateAsync(productEntity);
        }
    }
}
