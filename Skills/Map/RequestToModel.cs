using AutoMapper;
using Skills.Models;
using Skills.Shared.V1.Request;
using Skills.Shared.V1.Request.Queries;

namespace Skills.Map;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<PaginationQuery, PaginationFilter>();
        CreateMap<EntityQuery, ByEntityFilter>();

        CreateMap<CharacterRequestModel, CharacterModel>();
        CreateMap<SkillsRequestModel, SkillsModel>();
        CreateMap<ImageRequestModel, ImageModel>();
    }
}
