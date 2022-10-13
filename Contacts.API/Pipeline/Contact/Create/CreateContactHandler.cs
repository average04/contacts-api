using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API
{
    public class CreateContactHandler : IRequestHandler<CreateContactRequest, CreateContactResponse>
    {
        IContactDbContext _dbContext;
        public CreateContactHandler(IContactDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<CreateContactResponse> Handle(CreateContactRequest request, CancellationToken cancellationToken)
        {
            //Check for duplicate name
            var contact = _dbContext.Contact.Where(c => c.Name == request.Name).FirstOrDefault();

            if (contact != null)
            {
                foreach (var number in request.Numbers)
                {
                    //Check for duplicate number
                    if (!contact.Numbers.Contains(number))
                    {
                        contact.Numbers.Add(number);
                        _dbContext.Contact.Update(contact);
                    }
                }
            }
            else
            {
                contact = _dbContext.Contact.Add(new Contact
                {
                    Name = request.Name,
                    Numbers = request.Numbers,
                    IsStarred = false
                }).Entity;
            }

            _dbContext.SaveChangesAsync();

            return Task.FromResult(new CreateContactResponse() { Id = contact.Id });
        }
    }
}
