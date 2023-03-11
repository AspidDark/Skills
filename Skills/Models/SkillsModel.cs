namespace Skills.Models;

public class SkillsModel
{
    public Guid Id { get; set; }
    public required int Priority { get; init; }
    public required string SkillName { get; init; }
    public required int Level { get; init; }
    public Guid SkillPictureId { get; init; }
    public int IsMain { get; set; }

}