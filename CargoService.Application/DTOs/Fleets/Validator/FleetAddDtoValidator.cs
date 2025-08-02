using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.DTOs.Fleets.Validator
{
    public class FleetAddDtoValidator:AbstractValidator<FleetAddDto>
    {
        public FleetAddDtoValidator()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("Fleet name is required.")
                .MaximumLength(100).WithMessage("Fleet name must not exceed 100 characters.");
            RuleFor(f=>f.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(f=> f.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");
        }
    }
}
