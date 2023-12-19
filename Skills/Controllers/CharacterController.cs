using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skills.DataBase.DataAccess.Entities;
using Skills.Extensions;
using Skills.Map;
using Skills.Models;
using Skills.Services;
using Skills.Shared.V1;
using Skills.Shared.V1.Request;
using Skills.Shared.V1.Request.Queries;
using Skills.Shared.V1.Response;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skills.Controllers;
////https://stackoverflow.com/questions/34662966/json-net-serialization-of-ienumerable-with-typenamehandling-auto
[Authorize]
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

    [AllowAnonymous]
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
               ch => Ok(ModelToResponse.Map(ch)),
               errorModel => BadRequest(errorModel.Message)
               );
        }
        catch (Exception ex)
        { 
            return BadRequest(ex.Message);
        }
    }

    [AllowAnonymous]
    [HttpPost(ApiRoutes.CharacterRoute.CreateDraft)]
    public async Task<IActionResult> CreateDraft([FromBody] CharacterRequest request) 
    {
        try 
        {
            var model = _mapper.Map<CharacterModel>(request);
            var result = await _characterService.CreateDraft(model);

            return result.Match<IActionResult>(
              ch => Ok(ModelToResponse.Map(ch)),
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
                ch => Ok(ModelToResponse.Map(ch)),
                errorModel => BadRequest(errorModel.Message)
                );
        }
        catch(Exception ex) 
        {
            return BadRequest(ex.Message);
        }
    }



    [HttpPost(ApiRoutes.CharacterRoute.Create)]
    public async Task<IActionResult> Create([FromBody] CharacterRequest request)
    {
        try
        {
            var model = _mapper.Map<CharacterModel>(request);
            var userId = HttpContext.GetUserId();
            var result = await _characterService.Create(model, userId.Value);

            return result.Match<IActionResult>(
              ch => Ok(ModelToResponse.Map(ch)),
              errorModel => BadRequest(errorModel.Message)
              );
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut(ApiRoutes.CharacterRoute.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid characterId, [FromBody] CharacterRequest request)
    {
        try
        {
            var model = _mapper.Map<CharacterModel>(request);
            var userId = HttpContext.GetUserId();
            var result = await _characterService.Update(model, characterId, userId.Value);

            return result.Match<IActionResult>(
               ch => Ok(ModelToResponse.Map(ch)),
              errorModel => BadRequest(errorModel.Message)
              );
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [Authorize]
    [HttpDelete(ApiRoutes.CharacterRoute.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid characterId)
    {
        try
        {
            var userId = HttpContext.GetUserId();
            var result = await _characterService.Delete(characterId, userId.Value);
            return result.Match<IActionResult>(
            ch => Ok(ModelToResponse.Map(ch)),
            errorModel => BadRequest(errorModel.Message)
            );
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
