﻿// <auto-generated />
using System;
using DATA.CONTEXT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MIGRATION.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20231108160355_Booking_Tables")]
    partial class Booking_Tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DATA.EF_CORE.Booking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("BookingFrom")
                        .HasColumnType("longtext");

                    b.Property<string>("BookingStatus")
                        .HasColumnType("longtext");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<long?>("ShopBranchId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ShopId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShopBranchId");

                    b.HasIndex("ShopId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("DATA.EF_CORE.BookingDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("BookingId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<long?>("ShopBranchId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ShopId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("ShopBranchId");

                    b.HasIndex("ShopId");

                    b.ToTable("BookingsDetails");
                });

            modelBuilder.Entity("DATA.EF_CORE.BookingDetailService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("BookingDetailId")
                        .HasColumnType("bigint");

                    b.Property<long?>("BookingId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BookingDetailId");

                    b.HasIndex("BookingId");

                    b.HasIndex("ServiceId");

                    b.ToTable("BookingDetailServices");
                });

            modelBuilder.Entity("DATA.EF_CORE.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<long?>("CustomerAccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("ShopId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CustomerAccountId");

                    b.HasIndex("ShopId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DATA.EF_CORE.CustomerAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsVerify")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CustomerAccounts");
                });

            modelBuilder.Entity("DATA.EF_CORE.CustomerAccountDevice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<long>("CustomerAccountId")
                        .HasColumnType("bigint");

                    b.Property<string>("DeviceID")
                        .HasColumnType("longtext");

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("DeviceToken")
                        .HasColumnType("longtext");

                    b.Property<string>("DeviceType")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Os")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OsVersion")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SdkVersion")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CustomerAccountId");

                    b.ToTable("CustomerAccountDevices");
                });

            modelBuilder.Entity("DATA.EF_CORE.Service", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<long?>("ShopBranchId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ShopId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<string>("TimeUnit")
                        .HasColumnType("longtext");

                    b.Property<int?>("TimeValue")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ShopBranchId");

                    b.HasIndex("ShopId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("DATA.EF_CORE.Shop", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("CloseTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("CoverPicture")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Fax")
                        .HasColumnType("longtext");

                    b.Property<string>("Logo")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("OpenTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Region")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Since")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("DATA.EF_CORE.ShopBranch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("CloseTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Fax")
                        .HasColumnType("longtext");

                    b.Property<bool>("MainBranch")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("OpenTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Region")
                        .HasColumnType("longtext");

                    b.Property<long>("ShopId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("ShopBranchs");
                });

            modelBuilder.Entity("DATA.EF_CORE.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<long>("ShopBranchId")
                        .HasColumnType("bigint");

                    b.Property<long>("ShopId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.Property<long?>("UserGroupId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ShopBranchId");

                    b.HasIndex("ShopId");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DATA.EF_CORE.UserGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("DATA.EF_CORE.Booking", b =>
                {
                    b.HasOne("DATA.EF_CORE.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DATA.EF_CORE.ShopBranch", "ShopBranch")
                        .WithMany()
                        .HasForeignKey("ShopBranchId");

                    b.HasOne("DATA.EF_CORE.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId");

                    b.Navigation("Customer");

                    b.Navigation("Shop");

                    b.Navigation("ShopBranch");
                });

            modelBuilder.Entity("DATA.EF_CORE.BookingDetail", b =>
                {
                    b.HasOne("DATA.EF_CORE.Booking", "Booking")
                        .WithMany("BookingDetails")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DATA.EF_CORE.ShopBranch", "ShopBranch")
                        .WithMany()
                        .HasForeignKey("ShopBranchId");

                    b.HasOne("DATA.EF_CORE.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId");

                    b.Navigation("Booking");

                    b.Navigation("Shop");

                    b.Navigation("ShopBranch");
                });

            modelBuilder.Entity("DATA.EF_CORE.BookingDetailService", b =>
                {
                    b.HasOne("DATA.EF_CORE.BookingDetail", "BookingDetail")
                        .WithMany("BookingDetailServices")
                        .HasForeignKey("BookingDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DATA.EF_CORE.Booking", "Booking")
                        .WithMany()
                        .HasForeignKey("BookingId");

                    b.HasOne("DATA.EF_CORE.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("BookingDetail");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("DATA.EF_CORE.Customer", b =>
                {
                    b.HasOne("DATA.EF_CORE.CustomerAccount", "CustomerAccount")
                        .WithMany()
                        .HasForeignKey("CustomerAccountId");

                    b.HasOne("DATA.EF_CORE.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerAccount");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("DATA.EF_CORE.CustomerAccountDevice", b =>
                {
                    b.HasOne("DATA.EF_CORE.CustomerAccount", "CustomerAccount")
                        .WithMany()
                        .HasForeignKey("CustomerAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerAccount");
                });

            modelBuilder.Entity("DATA.EF_CORE.Service", b =>
                {
                    b.HasOne("DATA.EF_CORE.ShopBranch", "ShopBranch")
                        .WithMany()
                        .HasForeignKey("ShopBranchId");

                    b.HasOne("DATA.EF_CORE.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId");

                    b.Navigation("Shop");

                    b.Navigation("ShopBranch");
                });

            modelBuilder.Entity("DATA.EF_CORE.ShopBranch", b =>
                {
                    b.HasOne("DATA.EF_CORE.Shop", null)
                        .WithMany("ShopBranchs")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DATA.EF_CORE.User", b =>
                {
                    b.HasOne("DATA.EF_CORE.ShopBranch", null)
                        .WithMany("Users")
                        .HasForeignKey("ShopBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DATA.EF_CORE.Shop", null)
                        .WithMany("Users")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DATA.EF_CORE.UserGroup", null)
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId");
                });

            modelBuilder.Entity("DATA.EF_CORE.Booking", b =>
                {
                    b.Navigation("BookingDetails");
                });

            modelBuilder.Entity("DATA.EF_CORE.BookingDetail", b =>
                {
                    b.Navigation("BookingDetailServices");
                });

            modelBuilder.Entity("DATA.EF_CORE.Shop", b =>
                {
                    b.Navigation("ShopBranchs");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DATA.EF_CORE.ShopBranch", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DATA.EF_CORE.UserGroup", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
