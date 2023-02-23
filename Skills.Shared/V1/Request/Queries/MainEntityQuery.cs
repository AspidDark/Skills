using Microsoft.AspNetCore.Mvc;

namespace Skills.Shared.V1.Request.Queries;

public class MainEntityQuery
{
    [FromQuery(Name = "entityId")]
    public Guid EntityId { get; set; }

    [FromQuery(Name = "mainEntityId")]
    public Guid MainEntityId { get; set; }
}
