using System.Reflection;

namespace Stll.Core.Helpers;

public static class CoreAssemblyHelper
{
    public static Assembly Assembly => typeof(CoreAssemblyHelper).Assembly;
}