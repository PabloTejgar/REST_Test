using System.ComponentModel.DataAnnotations;

namespace REST_Test.Model.Models
{
    public class Product : IBaseModel
    {
        public int Id => ProductId;

        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public override string ToString() => Name;
    }
}
