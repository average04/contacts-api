using MediatR;

namespace Contacts.API
{
    public class GetContactByIdRequest : IRequest<Contact?>
    {
        public int Id { get; set; }
    }
}
