using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API
{
    public class DeleteContactHandler : IRequestHandler<DeleteContactRequest, bool>
    {
        IContactDbContext _dbContext;
        public DeleteContactHandler(IContactDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> Handle(DeleteContactRequest request, CancellationToken cancellationToken)
        {
            //Check for duplicate name
            var contact = _dbContext.Contact.Where(c => c.Id == request.Id).FirstOrDefault();

            if (contact != null)
            {
                _dbContext.Contact.Remove(contact);
                _dbContext.SaveChangesAsync();
            }
            else
                return Task.FromResult(false);


            return Task.FromResult(true);
        }
    }
}
