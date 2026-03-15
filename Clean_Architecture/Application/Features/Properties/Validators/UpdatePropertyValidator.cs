using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Repository;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.Features.Properties.Validators
{
   public class UpdatePropertyValidator:AbstractValidator<UpdateProperty>
    {
        public UpdatePropertyValidator(IPropertyRepo propertyrepo)
        {
            RuleFor(UpdateProperty => UpdateProperty.Address).NotEmpty().WithMessage("Address is required");
            RuleFor(UpdateProperty => UpdateProperty.Id).MustAsync(async (id,token) => await propertyrepo.GetByIdAsync(id) is not null).WithMessage("property doesnot exist");
        }
    }
}
