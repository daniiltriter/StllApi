using System.Reflection;

namespace Stll.Commands.Helpers;

public static class CqrsAssemblyHelper
{
    public static Assembly Assembly => typeof(CqrsAssemblyHelper).Assembly;
}