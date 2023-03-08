using Microsoft.EntityFrameworkCore;
using OneOf;
using Skills.DataBase.DataAccess;
using Skills.DataBase.DataAccess.Entities;
using Skills.Models;
using Skills.Shared.V1;

namespace Skills.Services;

public interface ICharacterService
{
    Task<OneOf<Character, ErrorModel>> Get(ByEntityFilter filter);

    Task<OneOf<List<Character>, ErrorModel>> GetList(BaseUserIdFilter filter, PaginationFilter paginationFilter);

    Task<OneOf<Character, ErrorModel>> Create(CharacterModel model, Guid userId);

    Task<OneOf<Character, ErrorModel>> Update(CharacterModel model, Guid characterId, Guid userId);

    Task<OneOf<int, ErrorModel>> Delete(Guid noteId, Guid userId);
}

public class CharacterService : ICharacterService
{
    private readonly AppDbContext _appDbContext;

    public CharacterService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<OneOf<Character, ErrorModel>> Get(ByEntityFilter filter)
    {
        var character = await _appDbContext.Characters
            .Include(x => x.Skills)
            .Include(x => x.Photo)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == filter.EntityId && x.OwnerId == filter.UserId);

        if (character is null)
        {
            return new ErrorModel(1001, $"Character with {filter.EntityId} not found");
        }

        return character;
    }

    public async Task<OneOf<List<Character>, ErrorModel>> GetList(BaseUserIdFilter filter, PaginationFilter paginationFilter)
    {
        var result = await _appDbContext.Characters.
            Include(x => x.Skills)
            .Include(x => x.Photo).Where(x => x.OwnerId == filter.UserId)
            .OrderBy(x => x.Priority)
            .Skip(paginationFilter.PageSize * paginationFilter.PageNumber)
            .Take(paginationFilter.PageSize)
            .AsNoTracking()
            .ToListAsync();

        if (result.Count == 0)
        {
            return new ErrorModel(1002, $"Character with PageNumber: {paginationFilter.PageNumber} PageSize: {paginationFilter.PageSize} not found");
        }
        return result;
    }

    public async Task<OneOf<Character, ErrorModel>> Create(CharacterModel model, Guid userId)
    {
        if (!IsCharacterValid(model))
        {
            return new ErrorModel(1100, "Character model is invalid skills mismach year of expirience");
        }
        var characterId = Guid.NewGuid();
        var character = CharacterMap(model, characterId, userId);

        var savedCharacter = _appDbContext.Characters.Add(character);

        var saveResult = await _appDbContext.SaveChangesAsync();
        //log
        return savedCharacter.Entity;
    }

    public async Task<OneOf<Character, ErrorModel>> Update(CharacterModel model, Guid characterId, Guid userId)
    {
        if (!IsCharacterValid(model))
        {
            return new ErrorModel(1100, "Character model is invalid skills mismach year of expirience");
        }
        var character = CharacterMap(model, characterId, userId);

        var updatedCharacter = _appDbContext.Characters.Update(character);
        var saveResult = await _appDbContext.SaveChangesAsync();
        //log
        return updatedCharacter.Entity;
    }

    public async Task<OneOf<int, ErrorModel>> Delete(Guid characterId, Guid userId)
    {
        var character = await _appDbContext.Characters
           .FirstOrDefaultAsync(x => x.Id == characterId && x.OwnerId == userId);
        if (character is null)
        {
            return new ErrorModel(1001, $"Character with {characterId} not found");
        }
        character.IsDeleted = 1;
        var saveResult = await _appDbContext.SaveChangesAsync();
        return saveResult;
    }

    private static Character CharacterMap(CharacterModel model, Guid cahracterId, Guid userId)
    => new()
    {
        Id = cahracterId,
        BuildName = model.BuildName,
        CreateDate = DateTime.UtcNow,
        EditDate = DateTime.UtcNow,
        IsDeleted = 0,
        OwnerId = userId,
        Photo = MapPhoto(model.Photo, userId),
        Priority = model.Priority,
        StartingDate = model.StartingDate,
        Story = model.Story,
        Skills = MapSkills(model.Skills, cahracterId, userId)
    };


    private static FileEntity? MapPhoto(ImageModel? image, Guid userId)
    {
        if (image is null)
        {
            return null;
        }

        return new()
        {
            CreateDate = DateTime.UtcNow,
            EditDate = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            IsDeleted = 0,
            OwnerId = userId,
            Path = image!.Path,
        };
    }

    private static List<Skill> MapSkills(IEnumerable<SkillsModel> skills, Guid characterId, Guid userId)
      => skills.Select(x => new Skill()
      {
          SkillName = x.SkillName,
          CahracterId = characterId,
          CreateDate = DateTime.UtcNow,
          EditDate = DateTime.UtcNow,
          Id = Guid.NewGuid(),
          Level = x.Level,
          Image = MapPhoto(x.Photo, userId),
          IsDeleted = 0,
          IsMain = x.IsMain,
          OwnerId = userId,
          Priority = x.Priority
      }).ToList();

    private static bool IsCharacterValid(CharacterModel model)
    {
        var today = DateTime.UtcNow;
        var maxSkill = (today.Year - model.StartingDate.Year - 1) +
        (((today.Month > model.StartingDate.Month) ||
        ((today.Month == model.StartingDate.Month) && (today.Day >= model.StartingDate.Day))) ? 1 : 0);

        var skillLevel = model.Skills.Select(x => x.Level).Sum();

        return maxSkill + 1 >= skillLevel;
    }
}

