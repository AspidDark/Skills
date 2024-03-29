﻿using AutoMapper;
using Duende.IdentityServer.Models;
using OneOf.Types;
using Skills.Models;
using Skills.Shared.V1.Request;
using Skills.Shared.V1.Request.Queries;
using System;

namespace Skills.Map;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<PaginationQuery, PaginationFilter>();
        CreateMap<EntityQuery, ByEntityFilter>();

        CreateMap<CharacterRequest, CharacterModel>()
            .ForMember(dest => dest.StartingDate, opt => opt.MapFrom(src => DateTime.Parse(src.StartingDate)));
        CreateMap<CharacterSkillRequest, CharacterSkillModel>();
        CreateMap<ImageRequestModel, ImageModel>();
        CreateMap<SkillImageRequestModel, SkillImageModel>();
    }
}
