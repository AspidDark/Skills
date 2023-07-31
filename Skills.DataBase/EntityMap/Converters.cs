using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Skills.DataBase.EntityMap;

public class DateTimeToDateTimeUtc : ValueConverter<DateTime, DateTime>
{
    public DateTimeToDateTimeUtc() : base(c => DateTime.SpecifyKind(c, DateTimeKind.Utc), c => c)
    {

    }
}

internal class Converters
{
}
