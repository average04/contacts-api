using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API
{
    public class UpdateContactHandler : IRequestHandler<UpdateContactRequest, bool>
    {
        IContactDbContext _dbContext;
        public UpdateContactHandler(IContactDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> Handle(UpdateContactRequest request, CancellationToken cancellationToken)
        {
            //Check for duplicate name
            var contact = _dbContext.Contact.Where(c => c.Id == request.Id).FirstOrDefault();

            if (contact != null)
            {
                contact.Name = request.Name;
                contact.Numbers = request.Numbers;
                contact.IsStarred = request.IsStarred;

                _dbContext.Contact.Update(contact);
                _dbContext.SaveChangesAsync();
            }
            else
                return Task.FromResult(false);


            return Task.FromResult(true);
        }
    }
}
