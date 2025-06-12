namespace ProjectEntityManagementWithCRUD.Models.DTO
{
    public class OrderReadDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }

        public string UserMail { get; set; }

        public ICollection<OrderItemReadDto> OrderItems { get; set; }
    }
}
