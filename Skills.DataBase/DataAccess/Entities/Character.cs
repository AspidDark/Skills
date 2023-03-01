using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skills.DataBase.DataAccess.Entities;

public class Character : BaseEntity
{
    public Guid UserId { get; set; }

    public int Priority { get; set; }

    public  string BuildName { get; set; }
    public  DateOnly StartingDate { get; set; }

    public Guid SkillId { get; set; }

    public Skill Speciality { get; set; }

    public virtual IEnumerable<Skill>? Skills { get; set; }

    public string? Story { get; set; }

    public Guid? PhotoId { get; set; }
    public FileEntity? Photo { get; set; }
}
