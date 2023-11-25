using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Infrastructure.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(u=>u.Username)
                .IsRequired()
                .HasColumnName("username")
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.Property(u=>u.Email)
                .HasColumnName("email")
                .HasDefaultValue("def")
                .IsRequired(false)
                .HasMaxLength(255);
            builder.Property<DateTime>("registration_date")
                .HasDefaultValue(DateTime.Now);
            builder.Property(u => u.Token)
                .HasColumnName("jwt_token")
                .HasDefaultValue("none");
        }
    }
}
