using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skills.Extensions;
using Skills.Models;
using Skills.Services;
using Skills.Shared.V1;
using Skills.Shared.V1.Request.Queries;

namespace Skills.Controllers;

//[Route("api/file")]
[Authorize]
[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public FileController(IMapper mapper, IFileService fileService)
    {
        _mapper = mapper;
        _fileService = fileService;
    }

    [HttpPost(ApiRoutes.FileRoute.Create)]
    public async Task<IActionResult> Create([FromForm] FileModel request)
    {
        try
        {
            FileCreate fileCreate = new()
            {
                UserId = HttpContext.GetUserId(),
                FileBody = request.FormFile
            };
            var result = await _fileService.Create(fileCreate);
            return result.Match<IActionResult>(
               id => Ok(id),
               errorModel => BadRequest(errorModel.Message)
               );
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet(ApiRoutes.FileRoute.Get)]
    public async Task<IActionResult> Get([FromQuery] EntityQuery entityByUserIdQuery)
    {
        try
        {
            var userId = HttpContext.GetUserId();
            var entityByUserIdfilter = _mapper.Map<ByEntityFilter>(entityByUserIdQuery);
            entityByUserIdfilter.UserId = userId;
            var result = await _fileService.Get(entityByUserIdQuery.EntityId);

            return result.Match<IActionResult>(
               fileStream => new FileStreamResult(fileStream.FileEntity, "application/octet-stream")
               {
                   FileDownloadName = fileStream.FileName
               },
               errorModel => BadRequest(errorModel.Message)
               );
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
