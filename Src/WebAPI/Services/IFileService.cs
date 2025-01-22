using Stll.Shared.Services;

namespace Stll.WebAPI.Services;

public interface IFileService
{
    Task<ServiceResponse<byte[]>> AsBytesAsync(params string[] pathParts);
}