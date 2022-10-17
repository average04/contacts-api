namespace Contacts.API
{
    public class IdNotFoundException : KeyNotFoundException
    {
        public string Key { get; set; }
        public IdNotFoundException(string key)
            : base($"{key} not found.")
        {
            Key = key;
        }
    }
}
