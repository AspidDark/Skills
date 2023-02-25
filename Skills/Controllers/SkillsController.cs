using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skills.Domain.Models;
using Skills.Extensions;
using Skills.Shared.V1;
using Skills.Shared.V1.Request.Queries;

namespace Skills.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SkillsController : ControllerBase
{
    public SkillsController()
    {
        
    }

    [HttpGet(ApiRoutes.SkillRoute.Get)]
    public async Task<IActionResult> Get([FromQuery] EntityQuery entityByUserIdQuery)
    {
        var userId = HttpContext.GetUserId();
        return Ok(new());
    }

    [HttpGet(ApiRoutes.SkillRoute.GetList)]
    public async Task<IActionResult> GetList([FromQuery] PaginationQuery paginationQuery)
    {
        return Ok(new());
    }

    [HttpPost(ApiRoutes.SkillRoute.Create)]
    public async Task<IActionResult> Create([FromBody] SkillsModel request)
    {
        return Ok(new());
    }

    [HttpPut(ApiRoutes.SkillRoute.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid skillId, [FromBody] SkillsModel request)
    {
        return Ok(new());
    }

    [HttpDelete(ApiRoutes.SkillRoute.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid skillId)
    {
        return Ok(new());
    }
}
