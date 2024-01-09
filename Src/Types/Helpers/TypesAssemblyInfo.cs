using System.Reflection;

namespace Stll.Types.Assemblies;

public static class TypesAssemblyHelper
{
    public static Assembly Assembly => typeof(TypesAssemblyHelper).Assembly;
}