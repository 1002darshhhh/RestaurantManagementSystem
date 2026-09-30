using Restaurant.API.DTOs;
using FluentValidation
;
public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(x=>x.Email).NotEmpty().EmailAddress();
        RuleFor(x=>x.Password).MinimumLength(6);
    }
}

