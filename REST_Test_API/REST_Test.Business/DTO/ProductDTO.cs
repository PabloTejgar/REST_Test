namespace REST_Test.Business.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public CategoryDTO Category { get; set; }
    }
}
