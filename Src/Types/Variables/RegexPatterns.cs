using System.ComponentModel.DataAnnotations;

namespace Stll.Types.Variables;

public static class RegexPatterns
{
    public const string SECURED_PASSWORD = @"^(?=.*[!@#$%^&*(),.?"":{}|<>])(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$";
}