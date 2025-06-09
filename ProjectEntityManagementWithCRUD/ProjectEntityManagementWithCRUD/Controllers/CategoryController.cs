using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEntityManagementWithCRUD.DBcontext;
using ProjectEntityManagementWithCRUD.Models;

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

        [HttpPost]
        [Route("AddCategory")]
        public async Task<string> AddCategory(Categories categories)
        {
            await categoryContext.Categories.AddAsync(categories);
            await categoryContext.SaveChangesAsync();
            return "Category added";
        }


        [HttpGet]
        [Route("GetCategory")]
        public async Task<List<Categories>> GetCategory()
        {
            return await categoryContext.Categories.ToListAsync();
        }

        [HttpGet]
        [Route("GetCategoryByID")]
        public async Task<Categories> GetCategoryByID(int id)
        {
            return await categoryContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<string> UpdateCategory(Categories categories)
        {
            categoryContext.Categories.Update(categories);
            await categoryContext.SaveChangesAsync();
            return "Category updated";
        }



        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<string> DeleteCategory(int id)
        {
            Categories categories = await categoryContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (categories == null)
            {
                return "Category not found";
            }
            else
            {
                categoryContext.Categories.Remove(categories);
                await categoryContext.SaveChangesAsync();
                return "Category deleted";
            }


        }
    }
}
