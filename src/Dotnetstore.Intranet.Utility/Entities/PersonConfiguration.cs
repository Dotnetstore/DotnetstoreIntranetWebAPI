using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnetstore.Intranet.Utility.Entities;

public abstract class PersonConfiguration<T> : BaseAuditableEntityConfiguration<T> where T : Person
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.LastName)
            .HasMaxLength(Constants.DefaultNameLength)
            .IsRequired()
            .IsUnicode();
        
        builder
            .Property(x => x.FirstName)
            .HasMaxLength(Constants.DefaultNameLength)
            .IsRequired()
            .IsUnicode();
        
        builder
            .Property(x => x.MiddleName)
            .HasMaxLength(Constants.DefaultNameLength)
            .IsRequired(false)
            .IsUnicode();
        
        builder
            .Property(x => x.EnglishName)
            .HasMaxLength(Constants.DefaultNameLength)
            .IsRequired(false)
            .IsUnicode();
        
        builder
            .Property(x => x.SocialSecurityNumber)
            .HasMaxLength(Constants.DefaultSocialSecurityNumberLength)
            .IsRequired(false)
            .IsUnicode(false);

        builder
            .Property(x => x.DateOfBirth)
            .IsRequired(false);

        builder
            .Property(x => x.IsMale)
            .IsRequired();

        builder
            .Property(x => x.LastNameFirst)
            .IsRequired();
    }
}