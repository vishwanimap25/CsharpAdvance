namespace StoreMVC.Models.Dto
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserPlan { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
