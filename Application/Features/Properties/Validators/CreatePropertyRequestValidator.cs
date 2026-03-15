using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Application.Features.Properties.Commands;

namespace Application.Features.Properties.Validators
{   public  class CreatePropertyRequestValidator:AbstractValidator<CreatePropertyRequest>
    {
        public CreatePropertyRequestValidator()
        {
            RuleFor(request => request.PropertyRequest).SetValidator(new NewPropertyValidator());
        }
    }
}
