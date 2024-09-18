using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnetstore.Intranet.Utility.Entities;

public abstract class IdentityConfiguration<T> : PersonConfiguration<T> where T : Identity
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);
        
        builder
            .Property(x => x.Username)
            .HasMaxLength(Constants.DefaultUsernameLength)
            .IsRequired()
            .IsUnicode(false);
        
        builder
            .Property(x => x.Password)
            .HasMaxLength(Constants.DefaultPasswordLength)
            .IsRequired()
            .IsUnicode(false);
        
        builder
            .Property(x => x.Salt1)
            .HasMaxLength(Constants.DefaultSaltLength)
            .IsRequired()
            .IsUnicode(false);
        
        builder
            .Property(x => x.Salt2)
            .HasMaxLength(Constants.DefaultSaltLength)
            .IsRequired()
            .IsUnicode(false);
        
        builder
            .Property(x => x.Salt3)
            .HasMaxLength(Constants.DefaultSaltLength)
            .IsRequired()
            .IsUnicode(false);
        
        builder
            .Property(x => x.Salt4)
            .HasMaxLength(Constants.DefaultSaltLength)
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