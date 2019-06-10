using StatelessServiceSample.Models;
using System.Collections.Generic;

namespace StatelessServiceSample.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable< Category> GetCategories();
        Category GetCategoryByID(int categoryId);
        void InsertCategory(Category category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category category);
        void Save();
    }
}
