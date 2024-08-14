using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnetstore.Intranet.Utility.Entities;

public abstract class IdentityConfiguration<T> : PersonConfiguration<T> where T : Identity
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);
        
        builder
            .Property(x => x.Username)
            .HasMaxLength(DataSchemaConstants.DefaultUsernameLength)
            .IsRequired()
            .IsUnicode(false);
        
        builder
            .Property(x => x.Password)
            .HasMaxLength(DataSchemaConstants.DefaultPasswordLength)
            .IsRequired()
            .IsUnicode(false);
        
        builder
            .Property(x => x.Salt1)
            .HasMaxLength(DataSchemaConstants.DefaultSaltLength)
            .IsRequired()
            .IsUnicode(false);
        
        builder
            .Property(x => x.Salt2)
            .HasMaxLength(DataSchemaConstants.DefaultSaltLength)
            .IsRequired()
            .IsUnicode(false);
        
        builder
            .Property(x => x.Salt3)
            .HasMaxLength(DataSchemaConstants.DefaultSaltLength)
            .IsRequired()
            .IsUnicode(false);
        
        builder
            .Property(x => x.Salt4)
            .HasMaxLength(DataSchemaConstants.DefaultSaltLength)
            .IsRequired()
            .IsUnicode(false);

        builder
            .Property(x => x.IsBlocked)
            .IsRequired();

        builder
            .Property(x => x.BlockedDate)
            .IsRequired(false);
    }
}