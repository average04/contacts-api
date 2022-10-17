using MediatR;

namespace Contacts.API
{
    public class UpdateContactRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Numbers { get; set; }
        public bool IsStarred { get; set; }
    }
}
