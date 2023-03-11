namespace Skills.Models.Response
{
    public class FileEntityResponseDto
    {
        public FileStream FileEntity { get; set; }
        public string FileName { get; set; }
        public Guid Id { get; set; }
    }
}
