using MediatR;

namespace Contacts.API
{
    public class CreateContactRequest : IRequest<CreateContactResponse>
    {
        public string Name { get; set; }
        public List<string> Numbers { get; set; }
    }
}
