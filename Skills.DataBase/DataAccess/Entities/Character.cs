namespace Skills.DataBase.DataAccess.Entities;

public class Character : BaseEntity
{
    public int Priority { get; set; }

    public  string BuildName { get; set; }
    public  DateOnly StartingDate { get; set; }

    public Guid SpecialityId { get; set; }

    public Skill Speciality { get; set; }

    public virtual IEnumerable<Skill>? Skills { get; set; }

    public string? Story { get; set; }

    public Guid? PhotoId { get; set; }
    public FileEntity? Photo { get; set; }
}
