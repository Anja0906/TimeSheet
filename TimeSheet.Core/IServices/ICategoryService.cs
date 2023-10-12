using TimeSheet.Core.Models;

namespace TimeSheet.Core.IServices
{
    public interface ICategoryService
    {
        Task<Category> GetByName(string name);
        Task<Category> AddCategory(Category category);
        void DeleteCategory(int id);
        Task<Category> UpdateCategory(Category category);
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
    }
}
