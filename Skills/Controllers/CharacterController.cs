using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skills.Extensions;
using Skills.Models;
using Skills.Shared.V1;
using Skills.Shared.V1.Request;
using Skills.Shared.V1.Request.Queries;

namespace Skills.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    private readonly IMapper _mapper;
    public CharacterController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet(ApiRoutes.CharacterRoute.Get)]
    public async Task<IActionResult> Get([FromQuery] EntityQuery entityByUserIdQuery)
    {
        var userId = HttpContext.GetUserId();
        var entityByUserIdfilter = _mapper.Map<ByEntityFilter>(entityByUserIdQuery);
        entityByUserIdfilter.UserId = userId;
        return Ok(new());
    }

    [HttpGet(ApiRoutes.CharacterRoute.GetList)]
    public async Task<IActionResult> GetList([FromQuery] PaginationQuery paginationQuery)
    {
        var paginationfilter = _mapper.Map<PaginationFilter>(paginationQuery);
        BaseUserIdFilter userIdFilter = new()
        {
            UserId = HttpContext.GetUserId()
        };
        return Ok(new());
    }

    [HttpPost(ApiRoutes.CharacterRoute.Create)]
    public async Task<IActionResult> Create([FromBody] CharacterRequestModel request)
    {
        var model = _mapper.Map<CharacterModel>(request);
        model.UserId = HttpContext.GetUserId();
        return Ok(new());
    }

    [HttpPut(ApiRoutes.CharacterRoute.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid characterId, [FromBody] CharacterRequestModel request)
    {
        var model = _mapper.Map<CharacterModel>(request);
        model.Id = characterId;
        model.UserId = HttpContext.GetUserId();
        return Ok(new());
    }

    [HttpDelete(ApiRoutes.CharacterRoute.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid characterId)
    {
        return Ok(new());
    }
}
