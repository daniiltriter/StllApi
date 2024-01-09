using Stll.Shared.Types;

namespace Stll.Shared.Services;

public interface IJwtTokenBuilder
{
    string Build(JwtData data);
}