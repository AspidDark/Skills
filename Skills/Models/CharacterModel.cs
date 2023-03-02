﻿namespace Skills.Models;

public class CharacterModel
{
    public Guid UserId { get; set; }

    public Guid Id { get; set; }
    public required int Priority { get; init; }

    public required string BuildName { get; init; }
    public required DateOnly StartingDate { get; set; }

    public IEnumerable<SkillsModel>? Skills { get; init; }
    public string? Story { get; set; }
    public required ImageModel Photo { get; init; }

}
