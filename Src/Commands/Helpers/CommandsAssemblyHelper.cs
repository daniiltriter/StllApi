using System.Reflection;

namespace Stll.Commands.Helpers;

public static class CommandsAssemblyHelper
{
    public static Assembly Assembly => typeof(CommandsAssemblyHelper).Assembly;
}