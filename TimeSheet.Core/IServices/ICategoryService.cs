using TimeSheet.Core.Models;

namespace TimeSheet.Core.IServices
{
    public interface ICategoryService
    {
        Task<Category> GetByName(string name);
        void AddCategory(Category category);
        void DeleteCategory(int id);
        Category UpdateCategory(Category category);
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
    }
}
