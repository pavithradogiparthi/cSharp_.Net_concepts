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
   public class UpdateImageRequestValidator:AbstractValidator<UpdateImageRequest>
    {
        public UpdateImageRequestValidator(IImageRepo imagerepo,IPropertyRepo propertyrepo)
        {
         RuleFor(request=>request.UpdateImage).SetValidator(new UpdateImageValidator(imagerepo,propertyrepo));

        }
    }
}
