using NewPractice.Model;

namespace NewPractice.Services
{
    public interface ICollection
    {
        public Task<User> AddUpdateUser (User user);
        public Task<Product> AddUpdateProduct (Product product);
        public Task<Category> AddUpdateCategory(Category category);
        public Task<Orders> AddUpdateOrders (Orders orders);
    }
}
