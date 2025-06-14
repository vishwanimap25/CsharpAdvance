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
        public async Task<IActionResult> AddCategory(Categories categories)
        {
            await categoryContext.Categories.AddAsync(categories);
            await categoryContext.SaveChangesAsync();
            return Ok("category added");
        }


        [HttpGet]
        public async Task<List<Categories>> GetCategory(int pageNumber = 1, int pageSize = 10)
        {
            var totalCount = await categoryContext.Categories.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            return await categoryContext.Categories.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            //return await categoryContext.Categories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Categories> GetCategoryByID(int id)
        {
            return await categoryContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

        }

        [HttpPut]
        public async Task<string> UpdateCategory(Categories categories)
        {
            categoryContext.Categories.Update(categories);
            await categoryContext.SaveChangesAsync();
            return "Category updated";
        }


        [HttpPatch("softDelete/{id}")]
        public async Task<string> softDelete(int id)
        {
            Categories categories = await categoryContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

            if(categories == null)
            {
                return "category not found";
            }
            else
            {
                if (categories.IsDeleted)
                {
                    return "product is already deleted";
                }
                categories.IsDeleted = true;
                await categoryContext.SaveChangesAsync();
                return "category deleted succesfully";
            }
        }






        //[HttpDelete]
        //[Route("DeleteCategory")]
        //public async Task<string> DeleteCategory(int id)
        //{
        //    Categories categories = await categoryContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
        //    if (categories == null)
        //    {
        //        return "Category not found";
        //    }
        //    else
        //    {
        //        categoryContext.Categories.Remove(categories);
        //        await categoryContext.SaveChangesAsync();
        //        return "Category deleted";
        //    }


        //}
    }
}
