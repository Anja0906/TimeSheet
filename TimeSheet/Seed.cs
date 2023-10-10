using System.Security.Claims;
using TimeSheet.Data;
using TimeSheet.Data.Entities;

namespace TimeSheet.WebAPI
{
    public class Seed
    {
        private readonly DataContext _dataContext;
        public Seed(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SeedDataContext()
        {
            if (!_dataContext.Categories.Any())
            {
                AddCategories();
                _dataContext.SaveChanges();

            }
        }

        private void AddCategories()
        {
            var categories = new List<Category>()
            {
                new Category(1, "frontend"),
                new Category(2, "backend")
            };

            _dataContext.Categories.AddRange(categories);


        }        

    }
}
