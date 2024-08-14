namespace Dotnetstore.Intranet.Utility.Entities;

public interface IBaseAuditableEntity
{
    Guid? LastUpdatedBy { get; }
    
    DateTimeOffset? LastUpdatedDate { get; }
    
    bool IsDeleted { get; }
    
    Guid? DeletedBy { get; }
    
    DateTimeOffset? DeletedDate { get; }
    
    bool IsSystem { get; }
    
    bool IsGdpr { get; }
}