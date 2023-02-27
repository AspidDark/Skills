using Microsoft.AspNetCore.Mvc;

namespace Skills.Shared.V1.Request.Queries;

public class EntityQuery
{
    [FromQuery(Name = "entityId")]
    public required Guid EntityId { get; init; }
}
