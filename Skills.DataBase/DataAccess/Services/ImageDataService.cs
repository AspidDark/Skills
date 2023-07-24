using Skills.DataBase.DataAccess.Entities;
namespace Skills.DataBase.DataAccess.Services;

public interface IImageDataService
{
    Task<FileEntity> CreateIfNotExist(FileEntity fileEntity);
}

public class ImageDataService: IImageDataService
{
    private readonly AppDbContext _appDbContext;

    public ImageDataService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<FileEntity> CreateIfNotExist(FileEntity fileEntity)
    {
        var existing = _appDbContext.SkillImages.FirstOrDefault(x => x.Id == fileEntity.Id);
        if (existing is not null)
        { 
            return existing;
        }
        _appDbContext.SkillImages.Add(fileEntity);
        await _appDbContext.SaveChangesAsync();
        return fileEntity;
    }

}
