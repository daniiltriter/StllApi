namespace Stll.Types.Variables;

public static class UsersErrorCodes
{
    public const string NOT_FOUND = "UserNotFound";
    
    public const string NAME_IS_EMPTY = "NameIsEmpty";
    public const string INVALID_NAME_LENGTH = "InvalidNameLength";
    
    public const string PASSWORD_IS_EMPTY = "PasswordIsEmpty";
    public const string INVALID_PASSWORD_LENGTH = "InvalidPasswordLenth";
    public const string PASSWORD_UNSECURE = "UnsecurePassword";
    public const string INVALID_PASSWORD = "InvalidPassword";
    
    public const string ALREADY_EXISTS = "UserAlreadyExists";
}