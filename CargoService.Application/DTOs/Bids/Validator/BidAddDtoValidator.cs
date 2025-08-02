using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.DTOs.Bids.Validator
{
    public  class BidAddDtoValidator:AbstractValidator<BidAddDto>

    {
        public BidAddDtoValidator()
        {
            RuleFor(b => b.LoadId).NotEmpty().WithMessage("LoadId is required!").
                GreaterThan(0).WithMessage("LoadId must be greater than 0.");
            RuleFor(b => b.FleetId)
                .NotEmpty().WithMessage("FleetId is required.")
                .GreaterThan(0).WithMessage("FleetId must be greater than 0.");
            RuleFor(b => b.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(b => b.BidTime)
                .NotEmpty().WithMessage("BidTime is required.");
        }


    }
}
