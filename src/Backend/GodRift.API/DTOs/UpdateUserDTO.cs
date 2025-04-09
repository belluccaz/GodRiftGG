namespace GodRift.API.DTOs
{
    public class UpdateUserDTO
    {
        public long UserId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}