using System.Reflection;

namespace Stll.WebAPI.Helpers;

public static class CoreAssemblyHelper
{
    public static Assembly Assembly => typeof(CoreAssemblyHelper).Assembly;
}