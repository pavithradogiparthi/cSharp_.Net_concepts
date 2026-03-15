using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Images.Commands;
using Application.Repository;
using FluentValidation;

namespace Application.Features.Images.Validators
{
   public class CreateImageRequestValidator:AbstractValidator<CreateImageRequest>
    {
        public CreateImageRequestValidator(IPropertyRepo propertyrepo)
        {
            RuleFor(request=>request.NewImage).SetValidator(new NewImageValidator(propertyrepo));   
        }
    }
}
