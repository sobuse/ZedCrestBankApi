﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZedCrestBankApi.ZDbContext;

namespace ZedCrestBankApi.Migrations
{
    [DbContext(typeof(ZedCrestBankingApiContext))]
    [Migration("20221031052249_updateDb")]
    partial class updateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZedCrestBankApi.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TransactionParticulars")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TranscationAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TranscationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TranscationDestinationAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TranscationSourceAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TranscationStatus")
                        .HasColumnType("int");

                    b.Property<int>("TranscationType")
                        .HasColumnType("int");

                    b.Property<string>("TranscationUniqueReference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transcations");
                });

            modelBuilder.Entity("ZedCrestBankApi.Models.WalletAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumberGenerator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CurrentWalletBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateLastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PinSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("WalletName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WalletType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Wallets");
                });
#pragma warning restore 612, 618
        }
    }
}
