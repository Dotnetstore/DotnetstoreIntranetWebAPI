namespace Dotnetstore.Intranet.Utility.Entities;

public abstract class Identity : Person
{
    public string Username { get; set; } = null!;
    
    public string Password { get; set; } = null!;
    
    public string Salt1 { get; set; } = null!;
    
    public string Salt2 { get; set; } = null!;
    
    public string Salt3 { get; set; } = null!;
    
    public string Salt4 { get; set; } = null!;
    
    public bool IsBlocked { get; set; }
    
    public DateTimeOffset? BlockedDate { get; set; }
}