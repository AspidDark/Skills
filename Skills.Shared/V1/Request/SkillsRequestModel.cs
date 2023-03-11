using System.ComponentModel.DataAnnotations;

namespace Skills.Shared.V1.Request;

public class SkillsRequestModel
{
    public required Guid Id { get; init; }
    public required int Priority { get; init; }

    [MaxLength(50)]
    public required string SkillName{ get; init; }
    public required int Level { get; init; }
    public required Guid SkillPictureId { get; init; }
    [Range(0,2)]
    public int IsMain { get; set; }
}
