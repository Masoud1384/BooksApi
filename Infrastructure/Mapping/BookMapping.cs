using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property<DateTime>("PublishDate")
                .HasDefaultValue(DateTime.Now);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b=>b.Description)
                .IsRequired()
                .HasMaxLength(228);

            builder.Property(t => t.Active)
                .IsRequired()
                .HasConversion(new BoolToStringConverter("DeActivated","Activated"));
        }
    }
}
