using Microsoft.EntityFrameworkCore;
using OneOf;
using Skills.DataBase.DataAccess.Entities;
using Skills.DataBase.DataAccess.Services;
using Skills.Models;
using Skills.Shared.V1;

namespace Skills.Services;

public interface ICharacterService
{
    Task<OneOf<Character, ErrorModel>> Get(ByEntityFilter filter);

    Task<OneOf<List<Character>, ErrorModel>> GetList(BaseUserIdFilter filter, PaginationFilter paginationFilter);

    Task<OneOf<Character, ErrorModel>> CreateDraft(CharacterModel model);

    Task<OneOf<Character, ErrorModel>> Create(CharacterModel model, Guid userId);

    Task<OneOf<Character, ErrorModel>> Update(CharacterModel model, Guid characterId, Guid userId);

    Task<OneOf<Character, ErrorModel>> Delete(Guid noteId, Guid userId);
}

public class CharacterService : ICharacterService
{
    private readonly ICharacterDataService _characterDataService;
    private readonly ICahracterSkillsDataService _characterSkillsDataService;
    private readonly ISkillDataService _skillDataService;
    private readonly IConfiguration _configuration;
    private readonly ISkillSetDataService _skillSetDataService;

    public CharacterService(ICharacterDataService characterDataService,
        ICahracterSkillsDataService characterSkillsDataService,
        ISkillDataService skillDataService,
        IConfiguration configuration,
        ISkillSetDataService skillSetDataService)
    {
        _characterDataService = characterDataService;
        _characterSkillsDataService = characterSkillsDataService;
        _skillDataService = skillDataService;
        _configuration = configuration;
        _skillSetDataService = skillSetDataService;
    }

    public async Task<OneOf<Character, ErrorModel>> Get(ByEntityFilter filter)
    {
        if (filter.EntityId.HasValue)
        {
            var result = await _characterDataService.GetById(filter.EntityId.Value);
            if (result is null)
            {
                return ErrorModelNoCharacter;
            }

            if (result.IsPublic)
            {
                result.SkillSet.Skills = await GetDeafultSkills(result.SkillSetId);
                return result;
            }

            if (!filter.UserId.HasValue)
            { 
                return ErrorModelNoCharacter;
            }

            //only authorized from here
            if (result.IsDraft) 
            {
                var undraftedCharacter = await _characterDataService.UpdateDraft(filter.EntityId.Value, filter.UserId.Value);
                undraftedCharacter.SkillSet.Skills = await GetDeafultSkills(result.SkillSetId);
                return undraftedCharacter;
            }

            if (result.OwnerId != filter.UserId)
            {
                return ErrorModelNoCharacter;
            }
            result.SkillSet.Skills = await GetDeafultSkills(result.SkillSetId);
            return result;
        }

        var defautlCharacter = await StarterCharacter();
        defautlCharacter.Id = Guid.Empty;
        return defautlCharacter;
    }

    public async Task<OneOf<Character, ErrorModel>> CreateDraft(CharacterModel model)
    {
        if (!IsCharacterValid(model))
        {
            return new ErrorModel(1100, "Character model is invalid skills mismatch year of expirience");
        }

        var character = await _characterDataService.CreateDraft(model);
        var skills = await _characterSkillsDataService.AddMany(model.Skills, character.Id);
        character.CharacterSkill = skills;
        var skillSet = await _skillSetDataService.GetSkillSet(model.SkillSetId);
        character.SkillSet = skillSet;
        return character;
    }



    public async Task<OneOf<List<Character>, ErrorModel>> GetList(BaseUserIdFilter filter, PaginationFilter paginationFilter)
    {
        if (!filter.UserId.HasValue)
        {
            return new ErrorModel(1101, "No user Id");
        }

        var result = await _characterDataService.GetList(filter.UserId.Value, paginationFilter.PageSize, paginationFilter.PageNumber);

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
            return new ErrorModel(1100, "Character model is invalid skills mismatch year of expirience");
        }

        var character = await _characterDataService.Create(model, userId);
        var skills = await _characterSkillsDataService.AddMany(model.Skills, character.Id);
        character.CharacterSkill = skills;
        var skillSet = await _skillSetDataService.GetSkillSet(model.SkillSetId);
        character.SkillSet = skillSet;
        return character;
    }

    public async Task<OneOf<Character, ErrorModel>> Update(CharacterModel model, Guid characterId, Guid userId)
    {
        if (!IsCharacterValid(model))
        {
            return new ErrorModel(1100, "Character model is invalid skills mismatch year of expirience");
        }
        var updatedCharacter = await _characterDataService.Update(model, characterId, userId);

        var skills = await _characterSkillsDataService.UpdateMany(model.Skills, characterId);
        updatedCharacter.CharacterSkill = skills;
        var skillSet = await _skillSetDataService.GetSkillSet(model.SkillSetId);
        updatedCharacter.SkillSet = skillSet;
        return updatedCharacter;
    }

    public async Task<OneOf<Character, ErrorModel>> Delete(Guid characterId, Guid userId)
    {
        var character = await _characterDataService.Delete(characterId, userId);
        if (character is null)
        {
            return new ErrorModel(1001, $"Character with {characterId} not found");
        }
        var skills = await _characterSkillsDataService.DeleteForCharacter(characterId, userId);
        character.CharacterSkill = skills;
        var skillSet = await _skillSetDataService.GetSkillSet(character.SkillSetId);
        character.SkillSet = skillSet;
        return character;
    }

    private async Task<List<Skill>> GetBySkillSetId(Guid skillSetid)
        => await _skillDataService.GetBySkillSetId(skillSetid);

    private static bool IsCharacterValid(CharacterModel model)
    {
        var today = DateTime.UtcNow;
        var maxSkill = (today.Year - model.StartingDate.Year - 1) +
        (((today.Month > model.StartingDate.Month) ||
        ((today.Month == model.StartingDate.Month) && (today.Day >= model.StartingDate.Day))) ? 1 : 0);

        var skillLevel = model.Skills.Select(x => x.Level + 1).Sum();

        return maxSkill + 1 >= skillLevel;
    }

    private static readonly ErrorModel ErrorModelNoCharacter = new(1001, "Character not found");

    private async Task<Character> StarterCharacter()
    {
        var defaultCharacterId = _configuration.GetValue<Guid>("DefaultCahracterId");
        var result = await _characterDataService.GetById(defaultCharacterId);
        result!.SkillSet.Skills = await GetDeafultSkills(result.SkillSetId);
        return result;
    }

    private async Task<List<Skill>?> GetDeafultSkills(Guid skillSetId)
        => await GetBySkillSetId(skillSetId);
}

