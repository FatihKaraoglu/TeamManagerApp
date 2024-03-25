﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamManager.Server.Data;

#nullable disable

namespace TeamManager.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TeamManager.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TeamManager.Shared.VacationBalance", b =>
                {
                    b.Property<int>("VacationBalanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacationBalanceId"), 1L, 1);

                    b.Property<int>("RemainingBalance")
                        .HasColumnType("int");

                    b.Property<int>("TotalBalance")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("VacationBalanceId");

                    b.HasIndex("UserId");

                    b.ToTable("vacationBalances");

                    b.HasData(
                        new
                        {
                            VacationBalanceId = 1,
                            RemainingBalance = 0,
                            TotalBalance = 20,
                            UserId = 1,
                            Year = 2024
                        },
                        new
                        {
                            VacationBalanceId = 2,
                            RemainingBalance = 0,
                            TotalBalance = 25,
                            UserId = 2,
                            Year = 2024
                        });
                });

            modelBuilder.Entity("TeamManager.Shared.VacationRequest", b =>
                {
                    b.Property<int>("VacationRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacationRequestId"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("VacationRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("VacationRequests");

                    b.HasData(
                        new
                        {
                            VacationRequestId = 1,
                            EndDate = new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Reason = "Vacation trip",
                            StartDate = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Approved",
                            UserId = 1
                        },
                        new
                        {
                            VacationRequestId = 2,
                            EndDate = new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Reason = "Family vacation",
                            StartDate = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Pending",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("TeamManager.Shared.VacationBalance", b =>
                {
                    b.HasOne("TeamManager.Shared.User", "User")
                        .WithMany("VacationBalances")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TeamManager.Shared.VacationRequest", b =>
                {
                    b.HasOne("TeamManager.Shared.User", "User")
                        .WithMany("VacationRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TeamManager.Shared.User", b =>
                {
                    b.Navigation("VacationBalances");

                    b.Navigation("VacationRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
