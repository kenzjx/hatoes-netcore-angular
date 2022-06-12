using FluentValidation;

namespace Beetsoft_Management_System.Systems
{
    public class RoleCreateRequestValidator : AbstractValidator<RoleCreateRequest>
    {
        public RoleCreateRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id value is required")
                             .MaximumLength(50).WithMessage("Id can not over 50 character limit");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Role name value is required");

        }
    }
}
