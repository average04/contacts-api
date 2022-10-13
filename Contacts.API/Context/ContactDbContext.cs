using Microsoft.EntityFrameworkCore;

namespace Contacts.API
{
    public class ContactDbContext : DbContext, IContactDbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContactConfigurations());
        }
    }
}
