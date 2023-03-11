namespace Skills.Models;

public class FileCreate
{
    public Guid UserId { get; set; }

    public IFormFile FileBody { get; set; }

}
