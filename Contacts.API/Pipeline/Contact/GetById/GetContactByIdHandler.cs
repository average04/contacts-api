using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API
{
    public class GetContactByIdHandler : IRequestHandler<GetContactByIdRequest, Contact?>
    {
        IContactDbContext _dbContext;
        public GetContactByIdHandler(IContactDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Contact?> Handle(GetContactByIdRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dbContext.Contact.Find(request.Id));
        }
    }
}
