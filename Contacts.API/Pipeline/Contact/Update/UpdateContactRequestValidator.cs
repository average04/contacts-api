using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using FluentValidation;

namespace Contacts.API
{
    public class UpdateContactRequestValidator : AbstractValidator<UpdateContactRequest>
    {
        public UpdateContactRequestValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0);

            RuleFor(request => request.Name)
               .NotNull()
               .NotEmpty();

            RuleFor(request => request.Numbers)
               .ForEach(r => r.NotEmpty()
               .NotNull().WithMessage("Phone Number is required.")
               .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
               .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
               .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid"));
        }
    }
}
