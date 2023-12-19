namespace Skills.Models;

public class ByEntityFilter : BaseUserIdFilter
{
    public Guid? EntityId { get; init; }
}
