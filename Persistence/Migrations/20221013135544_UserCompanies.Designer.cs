﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221013135544_UserCompanies")]
    partial class UserCompanies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int?>("BankruptcyCaseStartYear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusinessSector")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CompanyCreateDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CompanyLastUpdateDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeregistrationYear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IsBankrupt")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JARCODE")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("RegistrationYear")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginPassword")
                        .HasColumnType("TEXT");

                    b.Property<string>("Organization")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UserCreateDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UserLastUpdateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithMany("UserCompanies")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("UserCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}
