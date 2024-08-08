using System.ComponentModel.DataAnnotations;
using Blogging.Application.DTOs.Common;

namespace Blogging.Application.DTOs.AppUser;

public record AppUserDto : BaseDto
{
    [Required, EmailAddress] public string Email { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
    public string Name { get; set; }
    public string Nickname { get; set; }
}