using NewPractice.Db_context;
using NewPractice.Model;

namespace NewPractice.Services
{
    public class HomeServices : ICollection
    {
        private readonly ApplicationDb context;

        public HomeServices(ApplicationDb context)
        {
            this.context = context;
        }

        public async Task<Category> AddUpdateCategory(Category category)
        {
            var newCategory = await context.Category.FindAsync(category.Id);

            if(newCategory == null)
            {
                await context.Category.AddAsync(newCategory);
            }
            else
            {
                newCategory.Id = category.Id;
                newCategory.Name = category.Name;
            }
            await context.SaveChangesAsync();
            return newCategory;
        }

        public async Task<Orders> AddUpdateOrders(Orders orders)
        {
            var newOrder = await context.Orders.FindAsync(orders.Id);
            if(newOrder == null)
            {
                await context.Orders.AddAsync(orders);
            }
            else
            {
                newOrder.Id = orders.Id;
                newOrder.Name = orders.Name;
            }
            await context.SaveChangesAsync();
            return newOrder;
        }

        public async Task<Product> AddUpdateProduct(Product product)
        {
            var newProduct = await context.Product.FindAsync(product.Id);
            if(newProduct == null)
            {
                await context.Product.AddAsync(product);
            }
            else
            {
                newProduct.Id = product.Id;
                newProduct.Name = product.Name;
            }
            await context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<User> AddUpdateUser(User user)
        {
            var newUser = await context.User.FindAsync(user.Id);
            if(newUser == null)
            {
                await context.User.AddAsync(newUser);
            }
            else
            {
                newUser.Id = user.Id;
                newUser.Name = user.Name;
            }
            await context.SaveChangesAsync();
            return newUser;
        }
    }
}
