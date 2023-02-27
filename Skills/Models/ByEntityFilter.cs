namespace Skills.Models;

public class ByEntityFilter : BaseUserIdFilter
{
    public required Guid EntityId { get; init; }
}
