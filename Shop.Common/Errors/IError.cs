namespace Shop.Common
{
    using System.Collections.Generic;
    public enum ErrorCodes 
    {

        /// <summary>
        /// Gets the internal server error.
        /// </summary>
        InternalServerError = 10000,

        /// <summary>
        /// The argument.
        /// </summary>
        Argument = 10001,

        /// <summary>
        /// The argument null.
        /// </summary>
        ArgumentNull = 10002,

        /// <summary>
        /// The add login.
        /// </summary>
        AddLogin = 10008,

        /// <summary>
        /// The add password.
        /// </summary>
        AddPassword = 10009,

        /// <summary>
        /// The add user to role.
        /// </summary>
        AddUserToRole = 10010,

        /// <summary>
        /// The change password.
        /// </summary>
        ChangePassword = 10011,

        /// <summary>
        /// The invalid password.
        /// </summary>
        InvalidPassword = 10012,

        /// <summary>
        /// The invalid password reset token.
        /// </summary>
        InvalidPasswordResetToken = 10013,

        /// <summary>
        /// The update user.
        /// </summary>
        UpdateUser = 10014,

        /// <summary>
        /// The user already exists.
        /// </summary>
        UserAlreadyExists = 10015,

        /// <summary>
        /// The user not found.
        /// </summary>
        UserNotFound = 10016,

        /// <summary>
        /// The create user.
        /// </summary>
        CreateUser = 10017,

        /// <summary>
        /// The remove login.
        /// </summary>
        RemoveLogin = 10018,

        /// <summary>
        /// The remove user from role.
        /// </summary>
        RemoveUserFromRole = 10019,

        /// <summary>
        /// The not found.
        /// </summary>
        NotFound = 10020,

        /// <summary>
        /// The exception.
        /// </summary>
        Exception = 10021,


    }
    /// <summary>
    /// The Error interface.
    /// </summary>
    public interface IError
    {
        /// <summary>
        /// Gets the code.
        /// </summary>
        ErrorCodes ErrorCode { get; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        IEnumerable<string> Errors { get; }
    }
}
