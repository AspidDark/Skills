using System.ComponentModel.DataAnnotations;

namespace Skills.Shared.V1.Request;

public class SkillsRequestModel
{
    public required Guid Id { get; init; }
    public required int Priority { get; init; }

    [MaxLength(50)]
    public required string SkillName{ get; init; }
    public required Guid ImageId { get; init; }
    [Range(0,2)]
    public required int Level { get; init; }
    public int IsMain { get; set; }
}
