using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skills.Domain.Models;
using Skills.Extensions;
using Skills.Models;
using Skills.Shared.V1;
using Skills.Shared.V1.Request;
using Skills.Shared.V1.Request.Queries;

namespace Skills.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SkillsController : ControllerBase
{
    private readonly IMapper _mapper;
    public SkillsController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet(ApiRoutes.SkillRoute.Get)]
    public async Task<IActionResult> Get([FromQuery] EntityQuery entityByUserIdQuery)
    {
        var userId = HttpContext.GetUserId();
        var entityByUserIdfilter = _mapper.Map<ByEntityFilter>(entityByUserIdQuery);
        entityByUserIdfilter.UserId = userId;
        return Ok(new());
    }

    [HttpGet(ApiRoutes.SkillRoute.GetList)]
    public async Task<IActionResult> GetList([FromQuery] PaginationQuery paginationQuery)
    {
        var paginationfilter = _mapper.Map<PaginationFilter>(paginationQuery);
        BaseUserIdFilter userIdFilter = new()
        {
            UserId = HttpContext.GetUserId()
        };
        return Ok(new());
    }

    [HttpPost(ApiRoutes.SkillRoute.Create)]
    public async Task<IActionResult> Create([FromBody] SkillsRequestModel request)
    {
        var skillCreate = _mapper.Map<SkillsModel>(request);
        skillCreate.UserId = HttpContext.GetUserId();
        return Ok(new());
    }

    [HttpPut(ApiRoutes.SkillRoute.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid skillId, [FromBody] SkillsRequestModel request)
    {
        var skillUpdate = _mapper.Map<SkillsModel>(request);
        skillUpdate.Id = skillId;
        skillUpdate.UserId = HttpContext.GetUserId();
        return Ok(new());
    }

    [HttpDelete(ApiRoutes.SkillRoute.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid skillId)
    {
        return Ok(new());
    }
}
