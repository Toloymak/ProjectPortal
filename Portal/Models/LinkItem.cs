namespace Portal.Models;

public sealed record LinkItem
{
    public required string Text { get; init; }
    public required Uri Link { get; init; }
    
    public string? Description { get; init; }
}