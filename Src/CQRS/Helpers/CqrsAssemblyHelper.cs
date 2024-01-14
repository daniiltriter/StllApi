using System.Reflection;

namespace Stll.CQRS.Helpers;

public static class CqrsAssemblyHelper
{
    public static Assembly Assembly => typeof(CqrsAssemblyHelper).Assembly;
}