using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Properties.Queries;
using Application.Models;
using Application.Repository;
using Domain;
using FluentValidation;

namespace Application.Features.Images.Validators
{
    public  class NewImageValidator:AbstractValidator<NewImage>
    {
        public NewImageValidator(IPropertyRepo propertyRepo)
        {
            RuleFor(newImage=>newImage.PropertyId).
                MustAsync(async(propertyId,ct)=>await propertyRepo.GetByIdAsync(propertyId) is Property existingproperty)
                .WithMessage("Property doesnot exist");
            RuleFor(newimage => newimage.Name).NotEmpty();
            RuleFor(newimage=>newimage.Path).NotEmpty()
                .NotEmpty()
                .MinimumLength(100);
        }
    }
}
