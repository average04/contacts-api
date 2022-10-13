using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API
{
    public class GetContactsHandler : IRequestHandler<GetContactsRequest, List<Contact>>
    {
        IContactDbContext _dbContext;
        public GetContactsHandler(IContactDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Contact>> Handle(GetContactsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dbContext.Contact.ToList());
        }
    }
}
