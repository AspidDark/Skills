using Microsoft.EntityFrameworkCore;
using OneOf;
using Skills.DataBase.DataAccess;
using Skills.DataBase.DataAccess.Entities;
using Skills.DataBase.DataAccess.Services;
using Skills.Models;
using Skills.Shared.V1;

namespace Skills.Services;

public interface ICharacterService
{
    Task<OneOf<Character, ErrorModel>> Get(ByEntityFilter filter);

    Task<OneOf<List<Character>, ErrorModel>> GetList(BaseUserIdFilter filter, PaginationFilter paginationFilter);

    Task<OneOf<Character, ErrorModel>> Create(CharacterModel model, Guid userId);

    Task<OneOf<Character, ErrorModel>> Update(CharacterModel model, Guid characterId, Guid userId);

    Task<OneOf<Character, ErrorModel>> Delete(Guid noteId, Guid userId);
}

public class CharacterService : ICharacterService
{
    private readonly ICharacterDataService _characterDataService;
    private readonly ISkillsDataService _skillsDataService;

    public CharacterService(ICharacterDataService characterDataService, ISkillsDataService skillsDataService)
    {
        _characterDataService = characterDataService;
        _skillsDataService = skillsDataService;
    }
    public async Task<OneOf<Character, ErrorModel>> Get(ByEntityFilter filter)
    {
        var character = await _characterDataService.Get(filter.EntityId, filter.UserId);
        if (character is null)
        {
            return new ErrorModel(1001, $"Character with {filter.EntityId} not found");
        }
        return character;
    }

    public async Task<OneOf<List<Character>, ErrorModel>> GetList(BaseUserIdFilter filter, PaginationFilter paginationFilter)
    {
        var result = await _characterDataService.GetList(filter.UserId, paginationFilter.PageSize, paginationFilter.PageNumber);

        if (result is null || result.Count == 0)
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
        var characterToCraate = CharacterMap(model, userId);
        var character = await _characterDataService.Create(characterToCraate);

        var skillsToSave = MapSkills(model.Skills, character.Id, userId);

        var skills = await _skillsDataService.AddMany(skillsToSave);
        character.Skills = skills;
        return character;
    }

    public async Task<OneOf<Character, ErrorModel>> Update(CharacterModel model, Guid characterId, Guid userId)
    {
        if (!IsCharacterValid(model))
        {
            return new ErrorModel(1100, "Character model is invalid skills mismach year of expirience");
        }
        var characterToUpdate = CharacterMap(model, userId);
        var updatedCharacter = await _characterDataService.Update(characterToUpdate, characterId, userId);

        var skillsToUpdate = MapSkills(model.Skills, updatedCharacter.Id, userId);

        var skills = await _skillsDataService.UpdateMany(skillsToUpdate, characterId);
        updatedCharacter.Skills =skills;
        return updatedCharacter;
    }

    public async Task<OneOf<Character, ErrorModel>> Delete(Guid characterId, Guid userId)
    {
        var skills = await _skillsDataService.DeleteForCharacter(characterId, userId);
        var character = await _characterDataService.Delete(characterId, userId);
        if (character is null)
        {
            return new ErrorModel(1001, $"Character with {characterId} not found");
        }
        character.Skills = skills;
        return character;
    }

    private static Character CharacterMap(CharacterModel model, Guid userId)
    => new()
    {
        BuildName = model.BuildName,
        CreateDate = DateTime.UtcNow,
        EditDate = DateTime.UtcNow,
        IsDeleted = 0,
        OwnerId = userId,
        PhotoId = model.PhotoId,
        Priority = model.Priority,
        StartingDate = model.StartingDate,
        Story = model.Story,
    };

    private static List<Skill> MapSkills(IEnumerable<SkillsModel> skills, Guid characterId, Guid userId)
      => skills.Select(x => new Skill()
      {
          SkillName = x.SkillName,
          CahracterId = characterId,
          CreateDate = DateTime.UtcNow,
          EditDate = DateTime.UtcNow,
          Id = Guid.NewGuid(),
          Level = x.Level,
          ImageId = x.SkillPictureId,
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

