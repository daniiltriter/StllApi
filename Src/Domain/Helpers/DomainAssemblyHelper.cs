using System.Reflection;

namespace Stll.Domain.Helpers;

public static class DomainAssemblyHelper
{
    public static Assembly Assembly => typeof(DomainAssemblyHelper).Assembly;
}