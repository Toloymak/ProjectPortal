namespace Portal.Models;

public sealed record LinkBlock
{
    public required int Id { get; init; }
    
    // public required string Icon { get; init; }
    
    public required string Title { get; init; }
    public required string Description { get; init; }
    
    public required int Order { get; init; }
    
    public required IReadOnlyCollection<LinkItem> Items { get; init; }
}