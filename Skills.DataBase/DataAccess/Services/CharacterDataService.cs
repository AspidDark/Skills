using Microsoft.EntityFrameworkCore;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.DataAccess.Services;

public interface ICharacterDataService
{
    Task<Character?> GetById(Guid id);

    Task<Character?> GetByUserId(Guid userId);
    Task<List<Character>?> GetList(Guid userId, int pageSize, int pageNumber);

    Task<Character> Create(Character character);

    Task<Character> Update(Character character, Guid id, Guid userId);

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
          .Include(x => x.Skills)
          .Include(x => x.Photo)
          .AsNoTracking()
          .FirstOrDefaultAsync(x => x.Id == id);

    public Task<Character?> GetByUserId(Guid userId)
        => _appDbContext.Characters
          .Include(x => x.Skills)
          .Include(x => x.Photo)
          .AsNoTracking()
          .Where(x => x.Id == userId)
          .OrderBy(x=>x.Priority)
          .FirstOrDefaultAsync();

    public Task<List<Character>?> GetList(Guid userId, int pageSize, int pageNumber)
        => _appDbContext.Characters.
           Include(x => x.Skills)
           .Include(x => x.Photo).Where(x => x.OwnerId == userId)
           .OrderBy(x => x.Priority)
           .Skip(pageSize * pageNumber)
           .Take(pageSize)
           .AsNoTracking().ToListAsync();

    public async Task<Character> Create(Character character)
    {
        character.Id = Guid.NewGuid();
        var savedCharacter = _appDbContext.Characters.Add(character);
        await _appDbContext.SaveChangesAsync();
        return savedCharacter.Entity;
    }

    public async Task<Character?> Update(Character character, Guid id, Guid userId)
    {
        var characterFromDatabase = _appDbContext.Characters.FirstOrDefault(x => x.OwnerId == userId && x.Id == id);
        if (characterFromDatabase == null)
        {
            return null;
        }

        characterFromDatabase.IsDeleted = character.IsDeleted;
        characterFromDatabase.EditDate = DateTime.UtcNow;
        characterFromDatabase.Priority = character.Priority;
        characterFromDatabase.BuildName = character.BuildName;
        characterFromDatabase.StartingDate = character.StartingDate;
        characterFromDatabase.Story = character.Story;
        characterFromDatabase.PhotoId = character.PhotoId;
        await _appDbContext.SaveChangesAsync();
        return characterFromDatabase;
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
