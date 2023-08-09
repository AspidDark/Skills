using Skills.DataBase.DataAccess.Entities;
using Skills.Shared.V1.Response;

namespace Skills.Map
{
    public static class ModelToResponse
    {
        public static List<CharacterResponse> Map(IEnumerable<Character> characters)
            => characters.Select(x=>Map(x)).ToList();

        public static CharacterResponse Map(Character character)
         => new()
         {
             Id = character.Id,
             CreateDate = character.CreateDate,
             EditDate = character.EditDate,
             OwnerId = character.OwnerId,
             IsDeleted = character.IsDeleted,
             Priority = character.Priority,
             BuildName = character.BuildName,
             StartingDate = character.StartingDate,
             Story = character.Story,
             PhotoId = character.PhotoId,
             Photo = Map(character.Photo),
             Skills = character.Skills?.Select(x => Map(x)),
         };

        private static SkillResponse Map(Skill skill)
        => new()
        {
            Id = skill.Id,
            CreateDate = skill.CreateDate,
            EditDate = skill.EditDate,
            OwnerId = skill.OwnerId,
            IsDeleted = skill.IsDeleted,
            Priority = skill.Priority,
            SkillName = skill.SkillName,
            Level = skill.Level,
            ImageId = skill.ImageId,
            IsMain = skill.IsMain,
            Type = skill.Type,
            Image = Map(skill.Image),
        };

        private static FileEntityResponse? Map(FileEntity? file)
        {
            if (file is null)
            { 
                return null;
            }
            return new()
            {
                Id = file.Id,
                CreateDate = file.CreateDate,
                EditDate = file.EditDate,
                OwnerId = file.OwnerId,
                IsDeleted = file.IsDeleted,
                Path = file.Path
            };
        }

    }
}
