namespace Skills.Models
{
    public class SkillImageModel
    {
        public Guid Id { get; init; }
        public string Url { get; set; } = null!;
        public string? Path { get; set; }
    }
}
