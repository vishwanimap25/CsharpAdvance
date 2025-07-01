namespace ProjectEntityManagementWithCRUD.Models.DTO
{
    public class ProductCreateDto
    {

        public string Name { get; set; }

        public decimal Price { get; set; }

        // Required for mapping the product to a user
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
