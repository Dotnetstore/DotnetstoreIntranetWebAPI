namespace Dotnetstore.Intranet.Utility.Entities;

public abstract class Person : BaseAuditableEntity
{
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? EnglishName { get; set; }

    public string? SocialSecurityNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public bool IsMale { get; set; }

    public bool LastNameFirst { get; set; }

    public override string ToString()
    {
        if (LastNameFirst)
        {
            var name = $"{LastName}, {FirstName}";
            
            if (!string.IsNullOrEmpty(MiddleName))
            {
                name += $" {MiddleName}";
            }

            if (!string.IsNullOrEmpty(EnglishName))
            {
                name += $" ({EnglishName})";
            }
            
            return name;
        }
        else
        {
            var name = FirstName;
            
            if(!string.IsNullOrEmpty(MiddleName))
            {
                name += $" {MiddleName}";
            }
            
            name += $" {LastName}";
            
            if (!string.IsNullOrEmpty(EnglishName))
            {
                name += $" ({EnglishName})";
            }

            return name;
        }
    }
}