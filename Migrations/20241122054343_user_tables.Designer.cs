﻿// <auto-generated />
using System;
using JWPROJECT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JWPROJECT.Migrations
{
    [DbContext(typeof(JWContext))]
    [Migration("20241122054343_user_tables")]
    partial class user_tables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JWPROJECT.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("admin_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_login");
                });

            modelBuilder.Entity("JWPROJECT.Models.Project", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PId"));

                    b.Property<DateTime>("PAdd_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PCost")
                        .HasColumnType("int");

                    b.Property<string>("PDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PDocument")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PStatus")
                        .HasColumnType("int");

                    b.Property<string>("PZip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PId");

                    b.ToTable("tbl_project");
                });

            modelBuilder.Entity("JWPROJECT.Models.User", b =>
                {
                    b.Property<int>("UId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UId"));

                    b.Property<DateTime>("UAdded_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("UAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UCPass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UStatus")
                        .HasColumnType("int");

                    b.HasKey("UId");

                    b.ToTable("tbl_user");
                });
#pragma warning restore 612, 618
        }
    }
}
