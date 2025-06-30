using System.ComponentModel.DataAnnotations;

namespace TaskofSurpricseReview.Model
{
    public class Orders
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }

        public string productname { get; set; }


        public  int productid { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
