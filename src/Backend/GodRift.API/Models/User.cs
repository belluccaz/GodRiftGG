using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// Removed unnecessary using directive

namespace GodRiftGG.API.Models
{

    [Table("Users")]
    public class User
    {
        public long UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public required string Email { get; set; }

        [Required]
        public required string HashPassword { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}