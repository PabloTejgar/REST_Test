using System.ComponentModel.DataAnnotations;

namespace REST_Test.Model.Models
{
    public class Category : IBaseModel
    {
        public int Id => CategoryId;
        [Key]
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
        public override string? ToString() => Name;
    }
}
