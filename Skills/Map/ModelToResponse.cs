using Skills.DataBase.DataAccess.Entities;
using Skills.Shared.V1.Response;

namespace Skills.Map;

public static class ModelToResponse
{
    public static List<CharacterResponse> Map(IEnumerable<Character> characters)
        => characters.Select(x => Map(x)).ToList();

    public static CharacterResponse Map(Character character)
     => new()
     {
         Id = character.Id,
         OwnerId = character.OwnerId,
         Priority = character.Priority,
         BuildName = character.BuildName,
         StartingDate = character.StartingDate,
         Story = character.Story,
         PhotoId = character.PhotoId,
         Photo = Map(character.Photo),
         Skills = character.CharacterSkill?.Select(Map).OrderBy(x => x.Priority),
         SkillSet = Map(character.SkillSet),
     };

    public static CharacterSkillResponse Map(CharacterSkill skill)
    => new()
    {
        Id = skill.Id,
        OwnerId = skill.OwnerId,
        Priority = skill.Priority,
        CustomName = skill.CustomName,
        Level = skill.Level,
        IsMain = skill.IsMain,
        SkillId = skill.SkillId
    };

    public static SkillSetResponse Map(SkillSet skillSet)
        => new()
        {
            Id = skillSet.Id,
            OwnerId = skillSet.OwnerId,
            IsDefault = skillSet.IsDefault,
            Name = skillSet.Name,
            Skills = skillSet.Skills?.Select(Map).ToList(),
        };

    public static SkillResponse Map(Skill skill)
        => new()
        {
            Id = skill.Id,
            DefaultName = skill.DefaultName,
            Description = skill.Description,
            IsDefault = skill.IsDefault,
            OwnerId = skill.OwnerId,
            SkillLevelsData = skill.SkillLevelData?.Select(Map).ToList()
        };

    public static SkillLevelsInfoResponse Map(SkillLevelsInfo skillLevelsInfo)
        => new()
        { 
            Id = skillLevelsInfo.Id,
            Level = skillLevelsInfo.Level,
            Name = skillLevelsInfo.Name,
            OwnerId= skillLevelsInfo.OwnerId,
            Path = skillLevelsInfo.Path,
            Source = skillLevelsInfo.Source,
        };

    public static FileEntityResponse? Map(FileEntity? file)
    {
        if (file is null)
        { 
            return null;
        }
        return new()
        {
            Id = file.Id,
            OwnerId = file.OwnerId,
            Path = file.Path
        };
    }
}
