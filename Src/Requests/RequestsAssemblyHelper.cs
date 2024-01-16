using System.Reflection;

namespace Requests;

public static class RequestsAssemblyHelper
{
    public static Assembly Assembly => typeof(RequestsAssemblyHelper).Assembly;
}