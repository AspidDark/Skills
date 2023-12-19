using Skills.DataBase.DataAccess.Entities;
using Skills.Models;

namespace Skills.DataBase.DataAccess.Services;

public interface ICahracterSkillsDataService
{
    Task<List<CharacterSkill>> AddMany(IEnumerable<CharacterSkillModel> skillsModel, Guid characterId);
    Task<List<CharacterSkill>> UpdateMany(IEnumerable<CharacterSkillModel> skillsModel, Guid characterId);
    Task<List<CharacterSkill>?> DeleteForCharacter(Guid characterId, Guid userId);
}
public class CahracterSkillsDataService : ICahracterSkillsDataService
{
    private readonly AppDbContext _appDbContext;

    public CahracterSkillsDataService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<CharacterSkill>> AddMany(IEnumerable<CharacterSkillModel> skillsModel, Guid characterId)
    {
        var skills = skillsModel.Select(x => new CharacterSkill
        {
            Id = Guid.NewGuid(),
            CreateDate = DateTime.UtcNow,
            EditDate = DateTime.UtcNow,
            IsDeleted = 0,
            Priority = x.Priority,
            CustomName = x.CustomName,
            Level = x.Level,
            CharacterId = characterId,
            SkillId = x.SkillId,
            IsMain = x.IsMain,
        });
        await _appDbContext.CharacterSkills.AddRangeAsync(skills);
        await _appDbContext.SaveChangesAsync();
        return skills.ToList();
    }

    public async Task<List<CharacterSkill>> UpdateMany(IEnumerable<CharacterSkillModel> skillsModel, Guid characterId)
    {
        var skillsfromBase = _appDbContext.CharacterSkills.Where(x => x.Character.Id == characterId);
        _appDbContext.CharacterSkills.RemoveRange(skillsfromBase);
        _appDbContext.SaveChanges();
        var result = await AddMany(skillsModel, characterId);
        return result;
    }

    public async Task<List<CharacterSkill>?> DeleteForCharacter(Guid characterId, Guid userId)
    {
        var skills = _appDbContext.CharacterSkills.Where(x => x.OwnerId == userId && x.Character.Id == characterId);
        if (skills is null || skills.Count() == 0)
        {
            return null;
        }
        _appDbContext.RemoveRange(skills);
        await _appDbContext.AddRangeAsync();
        return skills.ToList();
    }
}
