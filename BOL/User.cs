using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
