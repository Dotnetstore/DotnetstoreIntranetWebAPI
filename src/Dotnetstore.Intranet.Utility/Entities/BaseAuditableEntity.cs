namespace Dotnetstore.Intranet.Utility.Entities;

public abstract class BaseAuditableEntity : IBaseAuditableEntity
{
    public Guid? CreatedBy { get; set; }
    
    public DateTimeOffset CreatedDate { get; set; }
    
    public Guid? LastUpdatedBy { get; set; }
    
    public DateTimeOffset? LastUpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
    
    public Guid? DeletedBy { get; set; }
    
    public DateTimeOffset? DeletedDate { get; set; }
    
    public bool IsSystem { get; set; }
    
    public bool IsGdpr { get; set; }
}