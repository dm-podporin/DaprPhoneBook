using System.ComponentModel.DataAnnotations;

namespace DaprPhoneBook.Models
{
    public record Contact
    {
        [Required(ErrorMessage = "Name cannot be null or empty.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Surname cannot be null or empty.")]
        public required string Surname { get; set; }

        [Required(ErrorMessage = "Phone cannot be null or empty.")]
        public required string Phone { get; set; }
    }
}
