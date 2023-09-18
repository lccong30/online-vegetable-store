﻿// <auto-generated />
using System;
using EcommerceV1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcommerceV1.Migrations
{
    [DbContext(typeof(EcommerceV1Context))]
    partial class EcommerceV1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcommerceV1.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("Salt")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("EcommerceV1.Models.Attribute", b =>
                {
                    b.Property<int>("AttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AttributeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttributeId"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AttributeId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("EcommerceV1.Models.AttributesPrice", b =>
                {
                    b.Property<int>("AttributesPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AttributesPriceID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttributesPriceId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("AttributeId")
                        .HasColumnType("int")
                        .HasColumnName("AttributeID");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.HasKey("AttributesPriceId");

                    b.HasIndex("AttributeId");

                    b.HasIndex("ProductId");

                    b.ToTable("AttributesPrices");
                });

            modelBuilder.Entity("EcommerceV1.Models.Category", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CatID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatId"));

                    b.Property<string>("Alias")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CatName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Cover")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Levels")
                        .HasColumnType("int");

                    b.Property<string>("MetaDesc")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MetaKey")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("Ordering")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("ParentID");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<string>("SchemaMarkup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumb")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Title")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("CatId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EcommerceV1.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("District")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nchar(150)")
                        .IsFixedLength();

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int")
                        .HasColumnName("LocationID");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Salt")
                        .HasMaxLength(8)
                        .HasColumnType("nchar(8)")
                        .IsFixedLength();

                    b.Property<int?>("Ward")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("LocationId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EcommerceV1.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .HasColumnType("int")
                        .HasColumnName("LocationID");

                    b.Property<int?>("Levels")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameWithType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Parent")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("LocationId")
                        .HasName("PK_Location");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("EcommerceV1.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("District")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int")
                        .HasColumnName("LocationID");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int")
                        .HasColumnName("PaymentID");

                    b.Property<DateTime?>("ShipDate")
                        .HasColumnType("datetime");

                    b.Property<int>("TotalMoney")
                        .HasColumnType("int");

                    b.Property<int>("TransactStatusId")
                        .HasColumnType("int")
                        .HasColumnName("TransactStatusID");

                    b.Property<int?>("Ward")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TransactStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EcommerceV1.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderDetailID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int?>("TotalMoney")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("EcommerceV1.Models.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PageID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PageId"));

                    b.Property<string>("Alias")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Contents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("MetaDesc")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MetaKey")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("Ordering")
                        .HasColumnType("int");

                    b.Property<string>("PageName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<string>("Thumb")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Title")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("PageId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("EcommerceV1.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Alias")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("BestSellers")
                        .HasColumnType("bit");

                    b.Property<int?>("CatId")
                        .HasColumnType("int")
                        .HasColumnName("CatID");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<bool>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<string>("MetaDesc")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MetaKey")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ShortDesc")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumb")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("UnitsInStock")
                        .HasColumnType("int");

                    b.Property<string>("Video")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ProductId");

                    b.HasIndex("CatId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EcommerceV1.Models.QuangCao", b =>
                {
                    b.Property<int>("QuangCaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("QuangCaoID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuangCaoId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ImageBg")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ImageBG");

                    b.Property<string>("ImageProduct")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SubTitle")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UrlLink")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("QuangCaoId");

                    b.ToTable("QuangCaos");
                });

            modelBuilder.Entity("EcommerceV1.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EcommerceV1.Models.Shipper", b =>
                {
                    b.Property<int>("ShipperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShipperID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipperId"));

                    b.Property<string>("Company")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<DateTime?>("ShipDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ShipperName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ShipperId");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("EcommerceV1.Models.TinDang", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PostID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<string>("Alias")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Author")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("CatId")
                        .HasColumnType("int")
                        .HasColumnName("CatID");

                    b.Property<string>("Contents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsHot")
                        .HasColumnType("bit")
                        .HasColumnName("isHot");

                    b.Property<bool>("IsNewfeed")
                        .HasColumnType("bit")
                        .HasColumnName("isNewfeed");

                    b.Property<string>("MetaDesc")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MetaKey")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<string>("Scontents")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("SContents");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumb")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Views")
                        .HasColumnType("int");

                    b.HasKey("PostId")
                        .HasName("PK_tblTinTucs");

                    b.ToTable("TinDangs");
                });

            modelBuilder.Entity("EcommerceV1.Models.TransactStatus", b =>
                {
                    b.Property<int>("TransactStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TransactStatusID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactStatusId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TransactStatusId");

                    b.ToTable("TransactStatus", (string)null);
                });

            modelBuilder.Entity("EcommerceV1.Models.Account", b =>
                {
                    b.HasOne("EcommerceV1.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_Accounts_Roles");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EcommerceV1.Models.AttributesPrice", b =>
                {
                    b.HasOne("EcommerceV1.Models.Attribute", "Attribute")
                        .WithMany("AttributesPrices")
                        .HasForeignKey("AttributeId")
                        .HasConstraintName("FK_AttributesPrices_Attributes");

                    b.HasOne("EcommerceV1.Models.Product", "Product")
                        .WithMany("AttributesPrices")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_AttributesPrices_Products");

                    b.Navigation("Attribute");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceV1.Models.Customer", b =>
                {
                    b.HasOne("EcommerceV1.Models.Location", "Location")
                        .WithMany("Customers")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_Customers_Locations");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("EcommerceV1.Models.Order", b =>
                {
                    b.HasOne("EcommerceV1.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Orders_Customers");

                    b.HasOne("EcommerceV1.Models.TransactStatus", "TransactStatus")
                        .WithMany("Orders")
                        .HasForeignKey("TransactStatusId")
                        .IsRequired()
                        .HasConstraintName("FK_Orders_TransactStatus");

                    b.Navigation("Customer");

                    b.Navigation("TransactStatus");
                });

            modelBuilder.Entity("EcommerceV1.Models.OrderDetail", b =>
                {
                    b.HasOne("EcommerceV1.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderDetails_Orders");

                    b.HasOne("EcommerceV1.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_OrderDetails_Products");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceV1.Models.Product", b =>
                {
                    b.HasOne("EcommerceV1.Models.Category", "Cat")
                        .WithMany("Products")
                        .HasForeignKey("CatId")
                        .HasConstraintName("FK_Products_Categories");

                    b.Navigation("Cat");
                });

            modelBuilder.Entity("EcommerceV1.Models.Attribute", b =>
                {
                    b.Navigation("AttributesPrices");
                });

            modelBuilder.Entity("EcommerceV1.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EcommerceV1.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EcommerceV1.Models.Location", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("EcommerceV1.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("EcommerceV1.Models.Product", b =>
                {
                    b.Navigation("AttributesPrices");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("EcommerceV1.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("EcommerceV1.Models.TransactStatus", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
