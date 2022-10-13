using MediatR;

namespace Contacts.API
{
    public class UpdateContactRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Number { get; set; }
        public bool IsStarred { get; set; }
    }
}
