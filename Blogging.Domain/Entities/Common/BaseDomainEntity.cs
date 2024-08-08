namespace Blogging.Domain.Entities.Common;

public class BaseDomainEntity 
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
}