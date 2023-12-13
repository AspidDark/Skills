using Microsoft.EntityFrameworkCore;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.DataAccess.Services;

public interface ISkillSetDataService
{
    Task<SkillSet> GetSkillSet(Guid id);
}

public class SkillSetDataService : ISkillSetDataService
{
    private readonly AppDbContext _appDbContext;
    public SkillSetDataService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<SkillSet> GetSkillSet(Guid id)
        => _appDbContext.SkillSets.Include(x=>x.Skills).FirstOrDefault(x => x.Id == id);
}
