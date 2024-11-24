﻿// <auto-generated />
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241123082426_AddCategoryToDbAndSeedTable")]
    partial class AddCategoryToDbAndSeedTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bulky.Models.Category", b =>
                {
                    b.Property<int>("CatigoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatigoryId"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CatigoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CatigoryId = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            CatigoryId = 2,
                            DisplayOrder = 2,
                            Name = "Scifi"
                        },
                        new
                        {
                            CatigoryId = 3,
                            DisplayOrder = 3,
                            Name = "History"
                        },
                        new
                        {
                            CatigoryId = 4,
                            DisplayOrder = 4,
                            Name = "DarkRomance"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}