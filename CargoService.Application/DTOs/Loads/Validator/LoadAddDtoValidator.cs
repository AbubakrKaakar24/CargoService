using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.DTOs.Loads.Validator
{
    public class LoadAddDtoValidator : AbstractValidator<LoadAddDto>
    {
        public LoadAddDtoValidator() { 
           RuleFor(l=>l.Origin).NotEmpty().WithMessage("Origin is required.")
                .MaximumLength(100).WithMessage("Origin must not exceed 100 characters.");
            RuleFor(l => l.Destination).NotEmpty().WithMessage("Destination is required.")
                .MaximumLength(100).WithMessage("Destination must not exceed 100 characters.");
            RuleFor(l => l.CargoType).NotEmpty().WithMessage("Cargo type is required.")
                .MaximumLength(50).WithMessage("Cargo type must not exceed 50 characters.");
            RuleFor(l => l.Weight).GreaterThan(0).WithMessage("Weight must be greater than 0.");
            RuleFor(l => l.PickupTime).NotEmpty().WithMessage("Pickup time is required.")
                .Must(p=> p > DateTime.UtcNow.AddHours(2)).WithMessage("Pickup time must be at least 2 hours from now.")
                ;
            RuleFor(l => l.PricingMode).NotEmpty().WithMessage("Pricing mode is required.")
                .MaximumLength(50).WithMessage("Pricing mode must not exceed 20 characters.");
            RuleFor(l => l.LoadStatus).IsInEnum().WithMessage("Invalid load status.");


        }
    }
}
