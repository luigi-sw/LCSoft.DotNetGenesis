using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace __company__.__project__.Application.Extensions;

public class AppErrorDescriber : IdentityErrorDescriber
{
    private readonly IStringLocalizer<AppErrorDescriber> _localizer;

    public AppErrorDescriber(IStringLocalizer<AppErrorDescriber> localizer)
    {
        _localizer = localizer;
    }

    public override IdentityError DefaultError()
        => new IdentityError
        {
            Code = nameof(DefaultError),
            Description = _localizer[nameof(DefaultError)]
        };

    public override IdentityError ConcurrencyFailure()
        => new IdentityError
        {
            Code = nameof(ConcurrencyFailure),
            Description = _localizer[nameof(ConcurrencyFailure)]
        };

    public override IdentityError PasswordMismatch()
        => new IdentityError
        {
            Code = nameof(PasswordMismatch),
            Description = _localizer[nameof(PasswordMismatch)]
        };

    public override IdentityError InvalidToken()
        => new IdentityError
        {
            Code = nameof(InvalidToken),
            Description = _localizer[nameof(InvalidToken)]
        };

    public override IdentityError LoginAlreadyAssociated()
        => new IdentityError
        {
            Code = nameof(LoginAlreadyAssociated),
            Description = _localizer[nameof(LoginAlreadyAssociated)]
        };

    public override IdentityError InvalidUserName(string? userName)
        => new IdentityError
        {
            Code = nameof(InvalidUserName),
            Description = string.Format(_localizer[nameof(InvalidUserName)], userName)
        };

    public override IdentityError InvalidEmail(string? email)
        => new IdentityError
        {
            Code = nameof(InvalidEmail),
            Description = string.Format(_localizer[nameof(InvalidEmail)], email)
        };

    public override IdentityError DuplicateUserName(string userName)
        => new IdentityError
        {
            Code = nameof(DuplicateUserName),
            Description = string.Format(_localizer[nameof(DuplicateUserName)], userName)
        };

    public override IdentityError DuplicateEmail(string email)
        => new IdentityError
        {
            Code = nameof(DuplicateEmail),
            Description = string.Format(_localizer[nameof(DuplicateEmail)], email)
        };

    public override IdentityError InvalidRoleName(string? role)
        => new IdentityError
        {
            Code = nameof(InvalidRoleName),
            Description = string.Format(_localizer[nameof(InvalidRoleName)], role)
        };

    public override IdentityError DuplicateRoleName(string role)
        => new IdentityError
        {
            Code = nameof(DuplicateRoleName),
            Description = string.Format(_localizer[nameof(DuplicateRoleName)], role)
        };

    public override IdentityError UserAlreadyHasPassword()
        => new IdentityError
        {
            Code = nameof(UserAlreadyHasPassword),
            Description = _localizer[nameof(UserAlreadyHasPassword)]
        };

    public override IdentityError UserLockoutNotEnabled()
        => new IdentityError
        {
            Code = nameof(UserLockoutNotEnabled),
            Description = _localizer[nameof(UserLockoutNotEnabled)]
        };

    public override IdentityError UserAlreadyInRole(string role)
        => new IdentityError
        {
            Code = nameof(UserAlreadyInRole),
            Description = string.Format(_localizer[nameof(UserAlreadyInRole)], role)
        };

    public override IdentityError UserNotInRole(string role)
        => new IdentityError
        {
            Code = nameof(UserNotInRole),
            Description = string.Format(_localizer[nameof(UserNotInRole)], role)
        };

    public override IdentityError PasswordTooShort(int length)
        => new IdentityError
        {
            Code = nameof(PasswordTooShort),
            Description = string.Format(_localizer[nameof(PasswordTooShort)], length)
        };

    public override IdentityError PasswordRequiresNonAlphanumeric()
        => new IdentityError
        {
            Code = nameof(PasswordRequiresNonAlphanumeric),
            Description = _localizer[nameof(PasswordRequiresNonAlphanumeric)]
        };

    public override IdentityError PasswordRequiresDigit()
        => new IdentityError
        {
            Code = nameof(PasswordRequiresDigit),
            Description = _localizer[nameof(PasswordRequiresDigit)]
        };

    public override IdentityError PasswordRequiresLower()
        => new IdentityError
        {
            Code = nameof(PasswordRequiresLower),
            Description = _localizer[nameof(PasswordRequiresLower)]
        };

    public override IdentityError PasswordRequiresUpper()
        => new IdentityError
        {
            Code = nameof(PasswordRequiresUpper),
            Description = _localizer[nameof(PasswordRequiresUpper)]
        };
}
