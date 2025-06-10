using Demo_08_IntroEF.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_08_IntroEF.Infrastructure.EntityConfigurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Table
            builder.ToTable("Person");

            // Clef
            builder.HasKey(p => p.Id)
                .HasName("PK_Person");

            // Props
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Firstname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Lastname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Ignore(p => p.Fullname);
        }
    }
}
