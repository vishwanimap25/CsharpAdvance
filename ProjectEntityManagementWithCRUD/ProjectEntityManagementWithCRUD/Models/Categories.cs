using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ProjectEntityManagementWithCRUD.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; } = string.Empty;

        public int CategoryCount { get; set; }

        //[DefaultValue(false)]
        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;

        //public DbSet<Products> Products { get; set; }


    }
}
