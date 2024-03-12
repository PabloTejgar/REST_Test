namespace REST_Test.Business.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public ICollection<ProductDTO>? Products { get; set; }
    }
}
