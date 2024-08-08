using Blogging.Domain.Entities.Common;

namespace Blogging.Domain.Entities;

public class Article : BaseDomainEntity
{
    public string Content { get; set; }
    public string Title { get; set; }
    public DateTime PostedDate { get; set; }
    public int UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
}