using System.ComponentModel.DataAnnotations;

namespace Skills.Shared.V1.Request;

public class CharacterRequestModel
{
    public required Guid Id { get; init; }
    public required int Priority { get; init; }
    [MaxLength(100)]
    public required string BuildName { get; init; }

    public required DateOnly StartingDate { get; set; }

    public required ImageRequestModel Photo { get; init; }

    [MaxLength(9)]
    public IEnumerable<SkillsRequestModel>? Skills { get; init; }
    [MaxLength(1000)]
    public string? Story { get; set; }
}
