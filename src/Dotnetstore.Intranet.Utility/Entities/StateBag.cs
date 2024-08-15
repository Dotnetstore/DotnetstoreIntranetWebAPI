using System.Diagnostics;

namespace Dotnetstore.Intranet.Utility.Entities;

public sealed class StateBag
{
    private readonly Stopwatch _sw = new();

    public string? Status { get; set; }
    public long DurationMillis => _sw.ElapsedMilliseconds;

    public StateBag() => _sw.Start();
}