using System.ComponentModel.DataAnnotations;

namespace Skills.Shared.V1.Request;

public class SkillRequestModel
{
    public Guid Id { get; init; }
    public required int Priority { get; init; }

    [MaxLength(50)]
    public required string SkillName{ get; init; }
    public required int Level { get; init; }
    [Range(0,2)]
    public int IsMain { get; set; }
    public required SkillImageRequestModel Image { get; init; }

    public string Type { get; init; } = null!;
}
