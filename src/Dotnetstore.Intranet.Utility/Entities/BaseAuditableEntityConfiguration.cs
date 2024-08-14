using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnetstore.Intranet.Utility.Entities;

public abstract class BaseAuditableEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseAuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .Property(x => x.CreatedBy)
            .IsRequired(false);
        
        builder
            .Property(x => x.CreatedDate)
            .IsRequired();
        
        builder
            .Property(x => x.LastUpdatedBy)
            .IsRequired(false);
        
        builder
            .Property(x => x.LastUpdatedDate)
            .IsRequired(false);
        
        builder
            .Property(x => x.IsDeleted)
            .IsRequired();
        
        builder
            .Property(x => x.DeletedBy)
            .IsRequired(false);
        
        builder
            .Property(x => x.DeletedDate)
            .IsRequired(false);
        
        builder
            .Property(x => x.IsSystem)
            .IsRequired();
        
        builder
            .Property(x => x.IsGdpr)
            .IsRequired();
    }
}