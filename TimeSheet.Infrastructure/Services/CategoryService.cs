using TimeSheet.Core.IRepositories;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;

namespace TimeSheet.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<Category> AddCategory(Category category)
        {
            return _categoryRepository.AddCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public Task<List<Category>> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Task<Category> UpdateCategory(Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }

        public Task<Category> GetByName(string name)
        {
           return _categoryRepository.GetByName(name);
        }

        public Task<Category> GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }
    }
}
