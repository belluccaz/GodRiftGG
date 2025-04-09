using System;

namespace GodRift.API.DTOs
{
    public class UserDTO
    {
        public long UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
}
