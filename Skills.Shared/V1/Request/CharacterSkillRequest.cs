using System.ComponentModel.DataAnnotations;

namespace Skills.Shared.V1.Request;

public class CharacterSkillRequest
{
    public Guid Id { get; init; }
    public required int Priority { get; init; }
    public string? CustomName { get; set; }
    public required int Level { get; init; }
    [Range(0,2)]
    public int IsMain { get; set; }
    public Guid SkillId { get; set; }
}
