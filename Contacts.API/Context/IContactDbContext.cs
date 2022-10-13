using Microsoft.EntityFrameworkCore;

namespace Contacts.API
{
    public interface IContactDbContext
    {
        DbSet<Contact> Contact { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
