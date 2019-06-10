using Microsoft.EntityFrameworkCore;
using StatelessServiceSample.DBContexts;
using StatelessServiceSample.Models;
using System.Collections.Generic;
using System.Linq;

namespace StatelessServiceSample.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _dbContext;

        public CategoryRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _dbContext.Categories.Find(categoryId);
            _dbContext.Categories.Remove(category);
            Save();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategoryByID(int categoryId)
        {
            return _dbContext.Categories.Find(categoryId);
        }

        public void InsertCategory(Category category)
        {
            _dbContext.Add(category);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            Save();
        }
    }
}
