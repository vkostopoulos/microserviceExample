using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class User
    {
        [Required]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

    }
}
