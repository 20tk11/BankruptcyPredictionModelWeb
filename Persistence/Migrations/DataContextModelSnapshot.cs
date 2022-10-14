﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Domain.Coef", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Audit")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CoefCreateDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CoefLastUpdateDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FinancialReportEstablishmentYear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FinancialReportLate")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FinancialYear")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FinancialYearsTillBankruptcy")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("NOR_1B_1")
                        .HasColumnType("REAL");

                    b.Property<double?>("NOR_1B_2")
                        .HasColumnType("REAL");

                    b.Property<int>("NumberOfEntries")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SingleShareholder")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Coefs");
                });

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

                    b.Property<Guid>("UserId")
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

            modelBuilder.Entity("Domain.Coef", b =>
                {
                    b.HasOne("Domain.Company", "Company")
                        .WithMany("CompanyCoefs")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.HasOne("Domain.User", "User")
                        .WithMany("UserCompanies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.Navigation("CompanyCoefs");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("UserCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}
