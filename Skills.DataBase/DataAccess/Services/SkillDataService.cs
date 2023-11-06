using Microsoft.EntityFrameworkCore;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.DataAccess.Services;

public interface ISkillDataService 
{
   Task <List<Skill>> GetBySkillSetId(Guid skillSetId);
}

public class SkillDataService: ISkillDataService
{
    private readonly AppDbContext _appDbContext;
    public SkillDataService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Skill>> GetBySkillSetId(Guid skillSetId)
     => await _appDbContext.Skills
            .Include(x => x.SkillLevelData)
            .Where(x => x.SkillSetId == skillSetId)
            .AsNoTracking()
            .ToListAsync();
}
