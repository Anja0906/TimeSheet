using AutoMapper;
using TimeSheet.Core.Exceptions;
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
        public Task<Category> AddCategory(Category category)
        {
             var categoryEntity = _mapper.Map<Entities.Category>(category);
            _dataContext.Categories.Add(categoryEntity);
            _dataContext.SaveChanges();
            var createdModel = _mapper.Map<Category>(categoryEntity);
            return Task.FromResult(createdModel);
        }

        public void DeleteCategory(int id)
        {
            var existingCategory = _dataContext.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (existingCategory == null)
            {
                throw new ResourceNotFoundException("Category with that id does not exist!");
            }
            _dataContext.Categories.Remove(existingCategory);
            _dataContext.SaveChanges();
        }

        public Task<Category> GetById(int id)
        {
            var categoryEntity = _dataContext.Categories.Where(p => p.Id == id).FirstOrDefault();
            if (categoryEntity == null)
            {
                throw new ResourceNotFoundException("Category with that id does not exist!");
                
            }
            var categoryModel = _mapper.Map<Category>(categoryEntity);
            return Task.FromResult(categoryModel);

        }

        public Task<Category> GetByName(string name)
        {
            var categoryEntity = _dataContext.Categories.Where(p => p.Name == name).FirstOrDefault();
            if (categoryEntity == null)
            {
                throw new ResourceNotFoundException("Category with that name does not exist!");
            }
            var categoryModel = _mapper.Map<Category>(categoryEntity);
            return Task.FromResult(categoryModel);
        }

        public Task<Category> UpdateCategory(Category category)
        {
            var existingCategory = _dataContext.Categories.Where(p => p.Id == category.Id).FirstOrDefault();
            if (existingCategory == null)
            {
                throw new ResourceNotFoundException("Category with that id does not exist!");                
            }
            _dataContext.Attach(existingCategory);
            _dataContext.Entry(existingCategory).CurrentValues.SetValues(category);
            _dataContext.SaveChanges();
            var updatedCategory = _dataContext.Categories.Where(p => p.Id == category.Id).FirstOrDefault();
            if (updatedCategory == null)
            {
                throw new ArgumentException();                
            }
            var mappedCategory = _mapper.Map<Category>(updatedCategory);
            return Task.FromResult(mappedCategory);
        }

        public Task<List<Category>> GetAll()
        {
            var categories = _dataContext.Categories.OrderBy(p => p.Id).ToList();
            List<Category> result = _mapper.Map<List<Category>>(categories);
            return Task.FromResult(result);
        }

    }
}
