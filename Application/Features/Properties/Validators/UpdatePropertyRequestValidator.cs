using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Properties.Commands;
using Application.Repository;
using FluentValidation;

namespace Application.Features.Properties.Validators
{
   public  class UpdatePropertyRequestValidator:AbstractValidator<UpdatePropertyRequest>
    {
        

        public UpdatePropertyRequestValidator(IPropertyRepo propertyRepo)
        {
            RuleFor(request=>request.UpdateProperty).SetValidator(new UpdatePropertyValidator(propertyRepo));
            
        }
    }
}
