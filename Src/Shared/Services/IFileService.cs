namespace Stll.Shared.Services;

public interface IFileService
{
    Task<ServiceResponse<byte[]>> AsBytesAsync(params string[] pathParts);
}