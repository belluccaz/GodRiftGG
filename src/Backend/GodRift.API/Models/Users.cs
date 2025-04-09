using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GodRift.API.Models
{

    [Table("Users")]

    public class Users
    {
        [Key]
        public long UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        [JsonIgnore]
        public string HashPassword { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public ICollection<Players>? Players { get; set; }
    }
}