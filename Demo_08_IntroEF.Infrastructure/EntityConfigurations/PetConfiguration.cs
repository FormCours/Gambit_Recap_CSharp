using Demo_08_IntroEF.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_08_IntroEF.Infrastructure.EntityConfigurations
{
    internal class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            // Table
            builder.ToTable("My_Pet", t =>
            {
                t.HasCheckConstraint("CK_My_Pet__Min_Name", "LENGTH(\"Name\") > 1");
            });

            // Clef primaire
            builder.HasKey(m => m.Id)
                .HasName("PK_My_Pet");

            // Props
            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Name)
                .HasMaxLength(50);
        }
    }
}
