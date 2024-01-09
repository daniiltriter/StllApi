using Stll.Types.Variables;

namespace Stll.Shared.Services;

public class FileService : IFileService
{
    public async Task<ServiceResponse<byte[]>> AsBytesAsync(params string[] pathParts)
    {
        var finalPath = pathParts.Aggregate(string.Empty, (current, path) => current + path);

        var isExists = File.Exists(finalPath);
        if (!isExists)
        {
            return ServiceResponse<byte[]>.Failed(FilesErrorCodes.NOT_FOUND);
        }
        
        var content =  await File.ReadAllBytesAsync(finalPath);  
        return ServiceResponse<byte[]>.Success(content); 
    }
}