using Stll.Core.Types;

namespace Stll.Core.Services;

public interface IJwtTokenBuilder
{
    string Build(JwtData data);
}