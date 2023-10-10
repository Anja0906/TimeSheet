﻿using TimeSheet.Core.Models;

namespace TimeSheet.Core.IRepositories
{
    public interface ICategoryRepository
    {
        Category GetByName(string name);
        void AddCategory(Category category);
        void DeleteCategory(int id);
        Category UpdateCategory(Category category);
        List<Category> GetAll();
        Category GetById(int id);
    }
}
