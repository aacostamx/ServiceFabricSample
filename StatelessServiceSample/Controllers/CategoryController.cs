using Microsoft.AspNetCore.Mvc;
using StatelessServiceSample.Models;
using StatelessServiceSample.Repository;
using System.Transactions;

namespace StatelessServiceSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryRepository.GetCategories();
            return new OkObjectResult(categories);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int id)
        {
            var category = _categoryRepository.GetCategoryByID(id);
            return new OkObjectResult(category);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            using (var scope = new TransactionScope())
            {
                _categoryRepository.InsertCategory(category);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Category category)
        {
            if (category != null)
            {
                using (var scope = new TransactionScope())
                {
                    _categoryRepository.UpdateCategory(category);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return new OkResult();
        }
    }
}