using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Accessor.Models
{
    public record Contact
    {

        public ObjectId? Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Phone { get; set; }
    }
    public record ContactDTO
    {

        [Required(ErrorMessage = "Name cannot be null or empty.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Surname cannot be null or empty.")]
        public required string Surname { get; set; }

        [Required(ErrorMessage = "Phone cannot be null or empty.")]
        public required string Phone { get; set; }
    }
}
