using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Repository;
using Domain;
using FluentValidation;

namespace Application.Features.Images.Validators
{
    public class UpdateImageValidator:AbstractValidator<UpdateImage>
    {
        public UpdateImageValidator(IImageRepo imagerepo,IPropertyRepo propertyRepo)
        {
            RuleFor(updateimage=>updateimage.Id).MustAsync(async(id,ct)=>await imagerepo.GetByIdAsync(id)is Image existingImage &&existingImage.Id == id)
                .WithMessage("Image doesnot exist");
            
        }
    }
}
