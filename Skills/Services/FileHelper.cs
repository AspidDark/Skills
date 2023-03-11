using Microsoft.Extensions.Options;
using Skills.Options;

namespace Skills.Services;

public interface IFileHelper
{
    FileStream GetFileStream(string path);

    Task<bool> SaveFile(IFormFile fromFile, string path);

    Task<bool> DeleteFile(string path);
}

public class FileHelper : IFileHelper
{
    private readonly FilePathOptions _options;
    public FileHelper(IOptions<FilePathOptions> options)
    {
        _options = options.Value;
    }

    public FileStream GetFileStream(string path)
    {
        try
        {
            string fileCompletePath = _options.BasePath + path;
            var image = File.OpenRead(fileCompletePath);
            return image;
        }
        catch (Exception ex)
        {
            throw;
        }
        //return File(image, "image/jpeg");
    }

    public async Task<bool> SaveFile(IFormFile fromFile, string path)
    {
        try
        {
            string filePath = _options.BasePath + path;
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await fromFile.CopyToAsync(fileStream);
            }
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> DeleteFile(string path)
    {
        try
        {
            string filePath = _options.BasePath + path;
            File.Delete(filePath);
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }

    }
}
