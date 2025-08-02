using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.DTOs.Trips.Validator
{
    public class TripAddDtoValidator:AbstractValidator<TripAddDto>
    {
        public TripAddDtoValidator() {
           RuleFor(t=> t.LoadId)
                .NotEmpty().WithMessage("LoadId is required.")
                .GreaterThan(0).WithMessage("LoadId must be greater than 0.");
            RuleFor(t => t.DriverId)
                .NotEmpty().WithMessage("DriverId is required.")
                .GreaterThan(0).WithMessage("DriverId must be greater than 0.");
            RuleFor(t => t.tripStatus)
                .IsInEnum().WithMessage("Invalid trip status.");
            RuleFor(t => t.StartTime)
                .NotEmpty().WithMessage("Start time is required.")
                .Must(s => s > DateTime.UtcNow).WithMessage("Start time must be now or in the future.");

        }
    }
}
