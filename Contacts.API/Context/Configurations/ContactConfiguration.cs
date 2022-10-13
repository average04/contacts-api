using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Contacts.API
{
    public class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey("Id");
            builder.Property(type => type.Id)
                .ValueGeneratedOnAdd();

            builder.Property(type => type.Name)
              .IsRequired()
              .HasColumnName("name")
              .HasMaxLength(250);

            builder.Property(type => type.Numbers)
              .HasConversion(
               v => JsonConvert.SerializeObject(v),
               v => JsonConvert.DeserializeObject<List<string>>(v));

            builder.Property(type => type.IsStarred)
               .IsRequired();
        }
    }
}
