﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniMailProject.Repository;

#nullable disable

namespace MiniMailProject.Repository.Migrations
{
    [DbContext(typeof(MailDbContext))]
    partial class MailDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MiniMailProject.Core.Entities.SendMail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SendMail");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "Seed özelliği denemek için oluşturduğum örnek verinin açıklaması",
                            CreatedDate = new DateTime(2023, 9, 10, 12, 44, 16, 436, DateTimeKind.Local).AddTicks(8904),
                            Subject = "Seed Özelliği",
                            To = "sametdikmendev@gmail.com"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
