using AutoMapper;
using CatalogAPI.Domain.Entities;
using CatalogAPI.DTOs;
using CatalogAPI.Repositories.Interfaces;
using CatalogAPI.Services.InterfaceService;

namespace CatalogAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepo.CreateAsync(categoryEntity);
        }

        public async Task Delete(int id)
        {
            var categoryEntity = _categoryRepo.GetByIdAsync(id).Result;
            await _categoryRepo.DeleteAsync(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var categoryEntity = await _categoryRepo.GetAllCategoriesAsync();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntity);
            return categoriesDto;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var categoryEntity = await _categoryRepo.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepo.UpdateAsync(categoryEntity);
        }
    }
}
