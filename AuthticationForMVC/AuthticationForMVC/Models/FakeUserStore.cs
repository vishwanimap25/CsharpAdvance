using Microsoft.EntityFrameworkCore;

namespace AuthticationForMVC.Models
{
    public static class FakeUserStore
    {
        public static List<User> User = new List<User>();
    }
}
