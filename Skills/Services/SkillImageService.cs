using Skills.DataBase.DataAccess.Entities;
using Skills.DataBase.DataAccess.Services;

namespace Skills.Services;

public interface ISkillImageService
{
    Task<List<FileEntity>> SaveSkillImages(IEnumerable<FileEntity> images);
}
public class SkillImageService: ISkillImageService
{
    private readonly IImageDataService _imageDataService;

    public SkillImageService(IImageDataService imageDataService)
    {
        _imageDataService = imageDataService;
    }
    public async Task<List<FileEntity>> SaveSkillImages(IEnumerable<FileEntity> images)
    {
        List<FileEntity> result = new();

        foreach (var item in images)
        {
            var saveResult = await _imageDataService.CreateIfNotExist(item);
            result.Add(saveResult);
        }
        return result;
    }
}
