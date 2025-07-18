﻿// <auto-generated />
using System;
using Demo_08_IntroEF.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Demo_08_IntroEF.Infrastructure.Migrations
{
    [DbContext(typeof(InfraDataContext))]
    [Migration("20250610141253_Update_Person_CreateAt")]
    partial class Update_Person_CreateAt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Demo_08_IntroEF.Infrastructure.Entity.Demo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("Desc");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id")
                        .HasName("PK_Demo");

                    b.HasIndex("Name")
                        .IsDescending()
                        .HasDatabaseName("IDX_Demo__Name");

                    b.ToTable("DemoEF", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Exemple de Seed data",
                            IsActive = true,
                            Name = "Ex1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Encore plus :o",
                            IsActive = false,
                            Name = "Ex2"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "Nullable"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Fin de l'exemple !",
                            IsActive = true,
                            Name = "Ex3"
                        });
                });

            modelBuilder.Entity("Demo_08_IntroEF.Infrastructure.Entity.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id")
                        .HasName("PK_Person");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("Demo_08_IntroEF.Infrastructure.Entity.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id")
                        .HasName("PK_My_Pet");

                    b.ToTable("My_Pet", null, t =>
                        {
                            t.HasCheckConstraint("CK_My_Pet__Min_Name", "LENGTH(\"Name\") > 1");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
