using MediatR;

namespace Contacts.API
{
    public class GetContactsRequest : IRequest<List<Contact>>
    {
    }
}
