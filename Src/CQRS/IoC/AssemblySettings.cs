using System.Collections.Immutable;
using System.Reflection;

namespace Stll.CQRS.IoC;

public class AssemblySettings
{
    private readonly ICollection<Assembly> _assemblies = new HashSet<Assembly>
    {
        typeof(AssemblySettings).Assembly
    };

    public void RegisterAssembly(Assembly assembly)
    {
        _assemblies.Add(assembly);
    }

    public Assembly[] GetAssemblies() => _assemblies.ToArray();
}