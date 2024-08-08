using System.ComponentModel.DataAnnotations;
using Blogging.Application.DTOs.Common;

namespace Blogging.Application.DTOs.AppUser;

public record LoginUserDto 
{
    [Required, EmailAddress] public string? Email { get; set; } = string.Empty;
    [Required] public string? Password { get; set; } = string.Empty;
}