using AutoMapper;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.Models;

namespace TimeSheet.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper _mapper;
        private DataContext _dataContext;
        public CategoryRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public void AddCategory(Category category)
        {
             var categoryEntity = _mapper.Map<Entities.Category>(category);
            _dataContext.Categories.Add(categoryEntity);
            _dataContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var existingCategory = _dataContext.Categories.Where(x => x.Id == id).FirstOrDefault();
            _dataContext.Categories.Remove(existingCategory);
            _dataContext.SaveChanges();
        }

        public List<Category> GetAll()
        {
            var categories = _dataContext.Categories.OrderBy(p => p.Id).ToList();
            List<Category> result = new List<Category>();
            foreach (var category in categories) 
            {
                var categoryModel = _mapper.Map<Category>(category);
                result.Add(categoryModel);
            }
            return result;
        }

        public Category GetById(int id)
        {
            var categoryEntity = _dataContext.Categories.Where(p => p.Id == id).FirstOrDefault();
            var categoryModel = _mapper.Map<Category>(categoryEntity);
            return categoryModel;
        }

        public Category GetByName(string name)
        {
            var categoryEntity = _dataContext.Categories.Where(p => p.Name == name).FirstOrDefault();
            var categoryModel = _mapper.Map<Category>(categoryEntity);
            return categoryModel;
        }

        public Category UpdateCategory(Category category)
        {
            var existingCategory = _dataContext.Categories.Where(p => p.Id == category.Id).FirstOrDefault();
            if (existingCategory != null)
            {
                _dataContext.Attach(existingCategory);
                _dataContext.Entry(existingCategory).CurrentValues.SetValues(category);
                _dataContext.SaveChanges();
            }
            var updatedCategory = _dataContext.Categories.Where(p => p.Id == category.Id).FirstOrDefault();
            if (updatedCategory != null) 
            {
                return _mapper.Map<Category>(updatedCategory);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
