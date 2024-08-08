using Blogging.Domain.Entities.Common;

namespace Blogging.Domain.Entities;

public class ApplicationUser :  BaseDomainEntity
{
    public string Name { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual List<Article> Articles { get; set; }
}