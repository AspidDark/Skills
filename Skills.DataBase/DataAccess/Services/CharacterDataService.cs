using Microsoft.EntityFrameworkCore;
using Skills.DataBase.DataAccess.Entities;
using Skills.Models;

namespace Skills.DataBase.DataAccess.Services;

public interface ICharacterDataService
{
    Task<Character?> GetById(Guid id);

    Task<List<Character>?> GetList(Guid userId, int pageSize, int pageNumber);

    Task<Character> CreateDraft(CharacterModel model);

    Task<Character> UpdateDraft(Guid characterId, Guid userId);

    Task<Character> Create(CharacterModel model, Guid userId);

    Task<Character> Update(CharacterModel model, Guid id, Guid userId);

    Task<Character?> Delete(Guid characterId, Guid userId);
}

public class CharacterDataService : ICharacterDataService
{
    private readonly AppDbContext _appDbContext;
    public CharacterDataService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Task<Character?> GetById(Guid id)
           => _appDbContext.Characters
          .AsNoTracking()
          .Include(x => x.CharacterSkill)
          .Include(x => x.Photo)
          .Include(x => x.SkillSet)
          .Include(x => x.SkillSet.Skills)
          .FirstOrDefaultAsync(x => x.Id == id);

    public Task<List<Character>?> GetList(Guid userId, int pageSize, int pageNumber)
        => _appDbContext.Characters
           .Include(x => x.CharacterSkill)
           .Include(x => x.Photo)
           .Include(x => x.SkillSet)
           .Include(x => x.SkillSet.Skills)
           .Where(x => x.OwnerId == userId)
           .OrderBy(x => x.Priority)
           .Skip(pageSize * pageNumber)
           .Take(pageSize)
           .AsNoTracking().ToListAsync();

    public async Task<Character> CreateDraft(CharacterModel model)
    {
        var character = new Character()
        {
            Id = Guid.NewGuid(),
            EditDate = DateTime.UtcNow,
            CreateDate = DateTime.UtcNow,
            IsDeleted = 0,
            Priority = model.Priority,
            BuildName = model.BuildName,
            Story = model.Story,
            PhotoId = model.PhotoId,
            StartingDate = model.StartingDate,
            SkillSetId = model.SkillSetId,
            IsPublic = false,
            IsDraft = true
        };
        var savedCharacter = _appDbContext.Characters.Add(character);
        await _appDbContext.SaveChangesAsync();
        return savedCharacter.Entity;
    }

    public async Task<Character> UpdateDraft(Guid characterId, Guid userId)
    {
        var character = _appDbContext.Characters.FirstOrDefault(x => x.Id == characterId)!;
        character.IsDraft = false;
        character.OwnerId = userId;
        await _appDbContext.SaveChangesAsync();
        return character;
    }
    
    public async Task<Character> Create(CharacterModel model, Guid userId)
    {
        var character = new Character()
        {
            Id = Guid.NewGuid(),
            EditDate = DateTime.UtcNow,
            CreateDate = DateTime.UtcNow,
            IsDeleted = 0,
            OwnerId = userId,
            Priority = model.Priority,
            BuildName = model.BuildName,
            Story = model.Story,
            PhotoId = model.PhotoId,
            StartingDate = model.StartingDate,
            SkillSetId = model.SkillSetId,
            IsPublic = model.IsPublic,
        };
        var savedCharacter = _appDbContext.Characters.Add(character);
        await _appDbContext.SaveChangesAsync();
        return savedCharacter.Entity;
    }

    public async Task<Character?> Update(CharacterModel model, Guid id, Guid userId)
    {
        var character = _appDbContext.Characters.FirstOrDefault(x => x.OwnerId == userId && x.Id == id);
        if (character == null)
        {
            return null;
        }
        character.EditDate = DateTime.UtcNow;
        character.Priority = model.Priority;
        character.BuildName = model.BuildName;
        character.Story = model.Story;
        character.PhotoId = model.PhotoId;
        character.SkillSetId = model.SkillSetId;
        character.StartingDate = model.StartingDate;
        character.IsPublic = model.IsPublic;

        await _appDbContext.SaveChangesAsync();
        return character;
    }

    public async Task<Character?> Delete(Guid characterId, Guid userId)
    {
        var character = await _appDbContext.Characters
           .FirstOrDefaultAsync(x => x.Id == characterId && x.OwnerId == userId);
        if (character is null)
        {
            return null;
        }

        _appDbContext.Remove(character);
        await _appDbContext.SaveChangesAsync();
        return character;
    }
}
