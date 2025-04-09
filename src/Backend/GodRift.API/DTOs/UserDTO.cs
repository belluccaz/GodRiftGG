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
    public class ReadUserDTO
    {
        public long UserId { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class CreateUserDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; } // Recebido em texto, mas criptografado no backend
    }

}
