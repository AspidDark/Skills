namespace Skills.DataBase.DataAccess.Entities;

public class Character : BaseEntity
{
    public int Priority { get; set; }

    public  string BuildName { get; set; }
    public  DateTime StartingDate { get; set; }

    public List<Skill>? Skills { get; set; }

    public string? Story { get; set; }

    public Guid? PhotoId { get; set; }
    public FileEntity? Photo { get; set; }
}
