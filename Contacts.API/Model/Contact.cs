namespace Contacts.API
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Numbers { get; set; }
        public bool IsStarred { get; set; }
    }
}
