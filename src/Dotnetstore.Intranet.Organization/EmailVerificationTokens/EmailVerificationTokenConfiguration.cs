namespace Dotnetstore.Intranet.Organization.EmailVerificationTokens;

internal sealed class EmailVerificationTokenConfiguration : BaseAuditableEntityConfiguration<EmailVerificationToken>
{
    public override void Configure(EntityTypeBuilder<EmailVerificationToken> builder)
    {
        base.Configure(builder);
        
        var converter = new ValueConverter<EmailVerificationTokenId, Guid>(
            id => id.Value, 
            guid => new EmailVerificationTokenId(guid));
        
        
        var userConverter = new ValueConverter<UserId, Guid>(
            id => id.Value, 
            guid => new UserId(guid));

        builder
            .HasIndex(x => x.Id)
            .IsUnique();

        builder
            .HasIndex(x => x.UserId)
            .IsUnique(false);
        
        builder
            .HasIndex(x => x.ExpireDate);
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasConversion(converter)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(x => x.UserId)
            .HasConversion(userConverter)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(x => x.ExpireDate)
            .HasColumnType("datetime2")
            .IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.EmailVerificationTokens)
            .HasForeignKey(x => x.UserId)
            .IsRequired();
    }
}