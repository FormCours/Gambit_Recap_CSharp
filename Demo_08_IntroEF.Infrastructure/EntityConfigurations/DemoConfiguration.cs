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
            builder.ToTable("DemoAdo");


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
        }
    }
}
