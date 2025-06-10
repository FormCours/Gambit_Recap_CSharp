using Microsoft.EntityFrameworkCore;
using Demo_08_IntroEF.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_08_IntroEF.Infrastructure.EntityConfigurations
{
    internal class DemoConfiguration : IEntityTypeConfiguration<Demo>
    {
        public void Configure(EntityTypeBuilder<Demo> builder)
        {
            // - Table
            builder.ToTable("DemoEF");


            // - Clef primaire
            builder.HasKey(m => m.Id)
                .HasName("PK_Demo");


            // - Props
            builder.Property(m => m.Id)
                .HasColumnType("INT")
                .HasColumnName("Id");

            //builder.Property(m => m.Name)
            //    .HasColumnType("VARCHAR(50)")
            //    .IsRequired();
            builder.Property(m => m.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(m => m.Description)
                .HasColumnName("Desc")
                .HasMaxLength(500);

            builder.Property(m => m.IsActive)
                .HasDefaultValue(true);


            // - Indexes
            builder.HasIndex(m => m.Name)
                .HasDatabaseName("IDX_Demo__Name")
                .IsDescending();

            // - Seeds
            builder.HasData([
                new Demo() {
                    Id = 1,
                    Name = "Ex1",
                    Description = "Exemple de Seed data",
                    IsActive = true,
                },
                new Demo() {
                    Id = 2,
                    Name = "Ex2",
                    Description = "Encore plus :o",
                    IsActive = false,
                },
                new Demo() {
                    Id = 3,
                    Name = "Nullable",
                    Description = null,
                    IsActive = true,
                },
                new Demo() {
                    Id = 4,
                    Name = "Ex3",
                    Description = "Fin de l'exemple !",
                    IsActive = true,
                }
            ]);
        }
    }
}
