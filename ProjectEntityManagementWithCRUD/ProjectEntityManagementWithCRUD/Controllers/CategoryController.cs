using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEntityManagementWithCRUD.DBcontext;
using ProjectEntityManagementWithCRUD.Models;
using ProjectEntityManagementWithCRUD.Models.DTO;

namespace ProjectEntityManagementWithCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DBContextFile categoryContext;

        public CategoryController(DBContextFile categoryContext)
        {
            this.categoryContext = categoryContext;
        }

        // (1) Add a new category
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDTO categoryDto)
        {
            var category = new Categories
            {
                Name = categoryDto.Name
            };

            await categoryContext.Categories.AddAsync(category);
            await categoryContext.SaveChangesAsync();

            return Ok("Category added successfully");
        }

        // (2) Get paged categories
        [HttpGet]
        public async Task<ActionResult<PagedResult<CateGoryReadDto>>> GetCategories(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and size must be greater than zero.");
            }

            var query = categoryContext.Categories.Where(c => !c.IsDeleted);

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            if (pageNumber > totalPages && totalPages > 0)
            {
                return NotFound("Page not found.");
            }

            var categories = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var categoryDtos = categories.Select(c => new CateGoryReadDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();


            return Ok(categoryDtos);
        }

        // (3) Get a single category by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CateGoryReadDto>> GetCategoryById(int id)
        {
            var category = await categoryContext.Categories
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (category == null)
            {
                return NotFound("Category not found");
            }

            var dto = new CateGoryReadDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(dto);
        }

        // (4) Update an existing category
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDTO categoryDto)
        {
            var category = await categoryContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null || category.IsDeleted)
            {
                return NotFound("Category not found");
            }

            category.Name = categoryDto.Name;

            await categoryContext.SaveChangesAsync();

            return Ok("Category updated successfully");
        }

        // (5) Soft delete a category
        [HttpPatch("softDelete/{id}")]
        public async Task<IActionResult> SoftDeleteCategory(int id)
        {
            var category = await categoryContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound("Category not found");
            }

            if (category.IsDeleted)
            {
                return BadRequest("Category is already deleted");
            }

            category.IsDeleted = true;
            await categoryContext.SaveChangesAsync();

            return Ok("Category soft deleted successfully");
        }
    }
}
