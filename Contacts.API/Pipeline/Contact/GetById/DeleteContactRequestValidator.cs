using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using FluentValidation;

namespace Contacts.API
{
    public class GetContactByIdRequestValidator : AbstractValidator<GetContactByIdRequest>
    {
        public GetContactByIdRequestValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0);
        }
    }
}
