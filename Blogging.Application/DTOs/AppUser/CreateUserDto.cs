using System.ComponentModel.DataAnnotations;

namespace Blogging.Application.DTOs.AppUser;

public record CreateUserDto 
{
    [Required, EmailAddress] public string? Email { get; set; } = string.Empty;
    [Required] public string? Password { get; set; } = string.Empty;
    [Required, Compare(nameof(Password))] public string? ConfirmPassword { get; set; } = string.Empty;
    public string Name { get; set; }
    public string Nickname { get; set; }
}