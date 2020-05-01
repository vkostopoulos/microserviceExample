using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

    }
}
