using Microsoft.EntityFrameworkCore;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.DataAccess.Services;

public interface ISkillsDataService
{
    Task<List<Skill>> AddMany(IEnumerable<Skill> skills);
    Task<List<Skill>> UpdateMany(IEnumerable<Skill> skills, Guid userId);
    Task<List<Skill>?> DeleteForCharacter(Guid characterId, Guid userId);
}
public class SkillsDataService : ISkillsDataService
{
    private readonly AppDbContext _appDbContext;

    public SkillsDataService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Skill>> AddMany(IEnumerable<Skill> skills)
    {
        await _appDbContext.Skills.AddRangeAsync(skills);
        await _appDbContext.SaveChangesAsync();
        return skills.ToList();
    }

    public async Task<List<Skill>> UpdateMany(IEnumerable<Skill> skills, Guid characterId)
    {
        var skillsfromBase =  _appDbContext.Skills.Where(x => x.Character.Id == characterId);
        _appDbContext.Skills.RemoveRange(skillsfromBase);
        _appDbContext.SaveChanges();
        _appDbContext.AddRange(skills);
        await _appDbContext.SaveChangesAsync();
        return skills.ToList();
    }

    public async Task<List<Skill>?> DeleteForCharacter(Guid characterId, Guid userId)
    {
        var skills = _appDbContext.Skills.Where(x => x.OwnerId == userId && x.Character.Id == characterId);
        if (skills is null || skills.Count() == 0)
        {
            return null;
        }
        _appDbContext.RemoveRange(skills);
        await _appDbContext.AddRangeAsync();
        return skills.ToList();
    }
}
