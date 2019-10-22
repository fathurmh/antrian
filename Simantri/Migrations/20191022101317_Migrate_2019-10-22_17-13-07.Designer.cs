﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Simantri.Data;

namespace Simantri.Migrations
{
    [DbContext(typeof(SimantriDbContext))]
    [Migration("20191022101317_Migrate_2019-10-22_17-13-07")]
    partial class Migrate_20191022_171307
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Simantri.Data.Domain.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue((short)1);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Value")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasDefaultValue("Not defined yet.");

                    b.HasKey("Id");

                    b.HasIndex("Key")
                        .IsUnique()
                        .HasName("UIX_Config_Key");

                    b.ToTable("Config");
                });
#pragma warning restore 612, 618
        }
    }
}
