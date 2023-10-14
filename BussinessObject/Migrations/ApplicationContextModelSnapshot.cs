﻿// <auto-generated />
using System;
using BussinessObject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BussinessObject.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BussinessObject.Models.Articles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JournalsId")
                        .HasColumnType("int");

                    b.Property<string>("SortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("JournalsId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("BussinessObject.Models.ArticlesRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticlesId")
                        .HasColumnType("int");

                    b.Property<int>("RatingScore")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticlesId");

                    b.HasIndex("UsersId");

                    b.ToTable("ArticlesRatings");
                });

            modelBuilder.Entity("BussinessObject.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BussinessObject.Models.Journals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UsersId");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("BussinessObject.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticlesId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReviewData")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticlesId");

                    b.HasIndex("UsersId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BussinessObject.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BussinessObject.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BussinessObject.Models.UsersRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("BussinessObject.Models.Articles", b =>
                {
                    b.HasOne("BussinessObject.Models.Journals", "Journals")
                        .WithMany("Articles")
                        .HasForeignKey("JournalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Journals");
                });

            modelBuilder.Entity("BussinessObject.Models.ArticlesRating", b =>
                {
                    b.HasOne("BussinessObject.Models.Articles", "Articles")
                        .WithMany("ArticlesRatings")
                        .HasForeignKey("ArticlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Users", "Users")
                        .WithMany("ArticlesRatings")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BussinessObject.Models.Journals", b =>
                {
                    b.HasOne("BussinessObject.Models.Category", "Category")
                        .WithMany("Journals")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Users", "Users")
                        .WithMany("Journals")
                        .HasForeignKey("UsersId");

                    b.Navigation("Category");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BussinessObject.Models.Review", b =>
                {
                    b.HasOne("BussinessObject.Models.Articles", "Articles")
                        .WithMany("Reviews")
                        .HasForeignKey("ArticlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Users", "Users")
                        .WithMany("Reviews")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BussinessObject.Models.UsersRole", b =>
                {
                    b.HasOne("BussinessObject.Models.Role", "Role")
                        .WithMany("UsersRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BussinessObject.Models.Users", "Users")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BussinessObject.Models.Articles", b =>
                {
                    b.Navigation("ArticlesRatings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BussinessObject.Models.Category", b =>
                {
                    b.Navigation("Journals");
                });

            modelBuilder.Entity("BussinessObject.Models.Journals", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("BussinessObject.Models.Role", b =>
                {
                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("BussinessObject.Models.Users", b =>
                {
                    b.Navigation("ArticlesRatings");

                    b.Navigation("Journals");

                    b.Navigation("Reviews");

                    b.Navigation("UsersRoles");
                });
#pragma warning restore 612, 618
        }
    }
}