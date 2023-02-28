using Skills.Models;
using Skills.Shared.V1;

namespace Skills.Services;

public interface ICharacterService
{
    Task<BaseResponse> Get(ByEntityFilter filter);

    Task<BaseResponse> GetList(ByEntityFilter filter, PaginationFilter paginationFilter);

    Task<BaseResponse> Create(CharacterModel model);

    Task<BaseResponse> Update(CharacterModel model);

    Task<BaseResponse> Delete(Guid noteId, Guid userId);
}
public class CharacterService : ICharacterService
{
    public async Task<BaseResponse> Get(ByEntityFilter filter)
    {
       throw new NotImplementedException();
    }

    public async Task<BaseResponse> GetList(ByEntityFilter filter, PaginationFilter paginationFilter)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse> Create(CharacterModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse> Update(CharacterModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse> Delete(Guid noteId, Guid userId)
    {
        throw new NotImplementedException();
    }
}

