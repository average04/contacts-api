using MediatR;

namespace Contacts.API
{
    public class DeleteContactRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
