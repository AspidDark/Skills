using Skills.DataBase.DataAccess.Entities;
using Skills.Models.Response;
using Skills.Models;
using Skills.Shared.V1;
using Skills.DataBase.DataAccess;
using OneOf;
using Microsoft.EntityFrameworkCore;
using Skills.DataBase.DataAccess.Services;

namespace Skills.Services;

public interface IFileService
{
    Task<OneOf<Guid, ErrorModel>> Create(FileCreate request);

    Task<OneOf<FileEntityResponseDto, ErrorModel>> Get(Guid fileId);
}

public class FileService : IFileService
{
    private readonly ILogger<FileService> _logger;
    private readonly AppDbContext _appDbContext;
    private readonly IFileHelper _fileHelper;
    

    public FileService(AppDbContext appDbContext, IFileHelper fileHelper)
    {
        _appDbContext = appDbContext;
        _fileHelper = fileHelper;
    }


    public async Task<OneOf<FileEntityResponseDto, ErrorModel>> Get(Guid fileId)
    {
        var fileInfo = await _appDbContext.Files.FirstOrDefaultAsync(x => x.Id == fileId);
        if (fileInfo == null)
        {
            return new ErrorModel(1007, "File not found");
        }
        var fileSream = _fileHelper.GetFileStream(fileInfo.Path);

        return new FileEntityResponseDto()
        {
            FileEntity = fileSream,
            Id = fileId,
            FileName = fileInfo.Path
        };
    }

    public async Task<OneOf<Guid, ErrorModel>> Create(FileCreate request)
    {
        //имя файла
        var fileName = request.FileBody.FileName;
        // var name = request.FileBody.Name;
        //Расширенеи файла
        string ext = Path.GetExtension(fileName);
        var fileId = Guid.NewGuid();

        //Имя файла для сохранения
        string fileSaveName = fileId.ToString() + fileName;

        if (!await _fileHelper.SaveFile(request.FileBody, fileSaveName))
        {
            return new ErrorModel(1006, "File Save Error");
        }

        FileEntity fileEntity = new()
        {
            Path = fileSaveName,
            Id = fileId,
            OwnerId = request.UserId,
        };

        var result = await _appDbContext.Files.AddAsync(fileEntity);
        var saveResult = await _appDbContext.SaveChangesAsync();

        if (saveResult == 0)
        {
            return new ErrorModel(1006, "File Save Error");
        }

        return fileId;
    }

   

}
