using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skills.Extensions;
using Skills.Models;
using Skills.Services;
using Skills.Shared.V1;
using Skills.Shared.V1.Request;
using Skills.Shared.V1.Request.Queries;

namespace Skills.Controllers;

//[Authorize]
[AllowAnonymous]
[ApiController]
//[Route("[controller]")]
public class CharacterController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICharacterService _characterService;
    public CharacterController(IMapper mapper, ICharacterService characterService)
    {
        _mapper = mapper;
        _characterService = characterService;
    }

    [HttpGet(ApiRoutes.CharacterRoute.Get)]
    public async Task<IActionResult> Get([FromQuery] EntityQuery entityByUserIdQuery)
    {
        try
        {
            var userId = HttpContext.GetUserId();
            var entityByUserIdfilter = _mapper.Map<ByEntityFilter>(entityByUserIdQuery);
            entityByUserIdfilter.UserId = userId;
            var result = await _characterService.Get(entityByUserIdfilter);

            return result.Match<IActionResult>(
                Ok,
                errorModel => BadRequest(errorModel.Message)
                );
        }
        catch (Exception ex)
        { 
            return BadRequest(ex.Message);
        }
    }

    [HttpGet(ApiRoutes.CharacterRoute.GetList)]
    public async Task<IActionResult> GetList([FromQuery] PaginationQuery paginationQuery)
    {
        try
        {
            var paginationfilter = _mapper.Map<PaginationFilter>(paginationQuery);
            BaseUserIdFilter userIdFilter = new()
            {
                UserId = HttpContext.GetUserId()
            };
            var result = await _characterService.GetList(userIdFilter, paginationfilter);

            return result.Match<IActionResult>(
                Ok,
                errorModel => BadRequest(errorModel.Message)
                );
        }
        catch(Exception ex) 
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(ApiRoutes.CharacterRoute.Create)]
    public async Task<IActionResult> Create([FromBody] CharacterRequestModel request)
    {
        try
        {
            var model = _mapper.Map<CharacterModel>(request);

            var userId = HttpContext.GetUserId();
            var result = await _characterService.Create(model, userId);

            return result.Match<IActionResult>(
              Ok,
              errorModel => BadRequest(errorModel.Message)
              );
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut(ApiRoutes.CharacterRoute.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid characterId, [FromBody] CharacterRequestModel request)
    {
        try
        {
            var model = _mapper.Map<CharacterModel>(request);
            var userId = HttpContext.GetUserId();
            var result = await _characterService.Update(model, characterId, userId);

            return result.Match<IActionResult>(
               Ok,
              errorModel => BadRequest(errorModel.Message)
              );
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete(ApiRoutes.CharacterRoute.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid characterId)
    {
        try
        {
            var userId = HttpContext.GetUserId();
            var result = await _characterService.Delete(characterId, userId);
            return result.Match<IActionResult>(
            Ok,
            errorModel => BadRequest(errorModel.Message)
            );
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
