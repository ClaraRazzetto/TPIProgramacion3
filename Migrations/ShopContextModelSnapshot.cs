﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.API.DBContexts;

#nullable disable

namespace Shop.API.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Shop.API.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Category = 0,
                            Name = "Remera basic",
                            Price = 10000f,
                            Size = 3,
                            Status = 0,
                            Stock = 3
                        },
                        new
                        {
                            Id = 5,
                            Category = 3,
                            Name = "Jean recto",
                            Price = 50000f,
                            Size = 2,
                            Status = 0,
                            Stock = 2
                        },
                        new
                        {
                            Id = 6,
                            Category = 4,
                            Name = "Campera basic",
                            Price = 60000f,
                            Size = 2,
                            Status = 0,
                            Stock = 1
                        },
                        new
                        {
                            Id = 7,
                            Category = 0,
                            Name = "Remera Nation",
                            Price = 30000f,
                            Size = 1,
                            Status = 0,
                            Stock = 0
                        });
                });

            modelBuilder.Entity("Shop.API.Entities.SaleOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleOrders");
                });

            modelBuilder.Entity("Shop.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Role").HasValue("User");
                });

            modelBuilder.Entity("Shop.API.Entities.Admin", b =>
                {
                    b.HasBaseType("Shop.API.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Email = "admin@gmail.com",
                            Password = "Password2",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Shop.API.Entities.Client", b =>
                {
                    b.HasBaseType("Shop.API.Entities.User");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Alem 1333",
                            Email = "clararazzetto@gmail.com",
                            LastName = "Razzetto",
                            Name = "Clara",
                            Password = "Password",
                            UserName = "ClaraRazzetto"
                        },
                        new
                        {
                            Id = 2,
                            Adress = "Urquiza 800",
                            Email = "nicop@gmail.com",
                            LastName = "Perez",
                            Name = "Nicolas",
                            Password = "Password1",
                            UserName = "NicolasPerez"
                        },
                        new
                        {
                            Id = 10,
                            Adress = "Alem 1400",
                            Email = "rox@gmail.com",
                            LastName = "Perez",
                            Name = "Roxana",
                            Password = "Password3",
                            UserName = "RoxanaPerez"
                        });
                });

            modelBuilder.Entity("Shop.API.Entities.SaleOrder", b =>
                {
                    b.HasOne("Shop.API.Entities.Client", "Client")
                        .WithMany("SaleOrders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.API.Entities.Product", "Product")
                        .WithMany("SaleOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop.API.Entities.Product", b =>
                {
                    b.Navigation("SaleOrders");
                });

            modelBuilder.Entity("Shop.API.Entities.Client", b =>
                {
                    b.Navigation("SaleOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
