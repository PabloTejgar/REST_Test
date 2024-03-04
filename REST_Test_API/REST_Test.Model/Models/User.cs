using System.ComponentModel.DataAnnotations;

namespace REST_Test.Model.Models
{
    /// <summary>
    /// User class to manage the access to the API.
    /// </summary>
    public class User : IBaseModel
    {
        public int Id => UserId;

        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public override string? ToString() => Name;
    }
}
