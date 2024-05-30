using System;
namespace TaskManagement.DTOs
{
    public class AuthRequestDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

