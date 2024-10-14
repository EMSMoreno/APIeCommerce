﻿// <auto-generated />
using System;
using APIeCommerce.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIeCommerce.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIeCommerce.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lanches",
                            UrlImage = "lanches1.png"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Combos",
                            UrlImage = "combos1.png"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Naturais",
                            UrlImage = "naturais1.png"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bebidas",
                            UrlImage = "refrigerantes1.png"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sucos",
                            UrlImage = "sucos1.png"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Sobremesas",
                            UrlImage = "sobremesas1.png"
                        });
                });

            modelBuilder.Entity("APIeCommerce.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("APIeCommerce.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("APIeCommerce.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<bool>("BestSeller")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Popular")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Available = true,
                            BestSeller = true,
                            CategoryId = 1,
                            Details = "Pão fofinho, hambúrger de carne bovina temperada, cebola, mostarda e ketchup ",
                            Name = "Hamburger padrão",
                            Popular = true,
                            Price = 15m,
                            Stock = 13,
                            UrlImage = "hamburger1.jpeg"
                        },
                        new
                        {
                            Id = 2,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 1,
                            Details = "Pão fofinho, hambúrguer de carne bovina temperada e queijo por todos os lados.",
                            Name = "CheeseBurger padrão",
                            Popular = true,
                            Price = 18m,
                            Stock = 10,
                            UrlImage = "hamburger3.jpeg"
                        },
                        new
                        {
                            Id = 3,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 1,
                            Details = "Pão fofinho, hambúrger de carne bovina temperada, cebola,alface, mostarda e ketchup ",
                            Name = "CheeseSalada padrão",
                            Popular = false,
                            Price = 19m,
                            Stock = 13,
                            UrlImage = "hamburger4.jpeg"
                        },
                        new
                        {
                            Id = 4,
                            Available = false,
                            BestSeller = false,
                            CategoryId = 2,
                            Details = "Pão fofinho, hambúrguer de carne bovina temperada e queijo, refrigerante e fritas",
                            Name = "Hambúrger, batata fritas, refrigerante ",
                            Popular = true,
                            Price = 25m,
                            Stock = 10,
                            UrlImage = "combo1.jpeg"
                        },
                        new
                        {
                            Id = 5,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 2,
                            Details = "Pão fofinho, hambúrguer de carne bovina ,refrigerante e fritas, cebola, maionese e ketchup",
                            Name = "CheeseBurger, batata fritas , refrigerante",
                            Popular = false,
                            Price = 27m,
                            Stock = 13,
                            UrlImage = "combo2.jpeg"
                        },
                        new
                        {
                            Id = 6,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 2,
                            Details = "Pão fofinho, hambúrguer de carne bovina ,refrigerante e fritas, cebola, maionese e ketchup",
                            Name = "CheeseSalada, batata fritas, refrigerante",
                            Popular = true,
                            Price = 28m,
                            Stock = 10,
                            UrlImage = "combo3.jpeg"
                        },
                        new
                        {
                            Id = 7,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 3,
                            Details = "Pão integral com folhas e tomate",
                            Name = "Lanche Natural com folhas",
                            Popular = false,
                            Price = 14m,
                            Stock = 13,
                            UrlImage = "lanche_natural1.jpeg"
                        },
                        new
                        {
                            Id = 8,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 3,
                            Details = "Pão integral, folhas, tomate e queijo.",
                            Name = "Lanche Natural e queijo",
                            Popular = true,
                            Price = 15m,
                            Stock = 10,
                            UrlImage = "lanche_natural2.jpeg"
                        },
                        new
                        {
                            Id = 9,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 3,
                            Details = "Lanche vegano com ingredientes saudáveis",
                            Name = "Lanche Vegano",
                            Popular = false,
                            Price = 25m,
                            Stock = 18,
                            UrlImage = "lanche_vegano1.jpeg"
                        },
                        new
                        {
                            Id = 10,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 4,
                            Details = "Refrigerante Coca Cola",
                            Name = "Coca-Cola",
                            Popular = true,
                            Price = 21m,
                            Stock = 7,
                            UrlImage = "coca_cola1.jpeg"
                        },
                        new
                        {
                            Id = 11,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 4,
                            Details = "Refrigerante de Guaraná",
                            Name = "Guaraná",
                            Popular = false,
                            Price = 25m,
                            Stock = 6,
                            UrlImage = "guarana1.jpeg"
                        },
                        new
                        {
                            Id = 12,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 4,
                            Details = "Refrigerante Pepsi Cola",
                            Name = "Pepsi",
                            Popular = false,
                            Price = 21m,
                            Stock = 6,
                            UrlImage = "pepsi1.jpeg"
                        },
                        new
                        {
                            Id = 13,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 5,
                            Details = "Suco de laranja saboroso e nutritivo",
                            Name = "Suco de laranja",
                            Popular = false,
                            Price = 11m,
                            Stock = 10,
                            UrlImage = "suco_laranja.jpeg"
                        },
                        new
                        {
                            Id = 14,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 5,
                            Details = "Suco de morango fresquinhos",
                            Name = "Suco de morango",
                            Popular = false,
                            Price = 15m,
                            Stock = 13,
                            UrlImage = "suco_morango1.jpeg"
                        },
                        new
                        {
                            Id = 15,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 5,
                            Details = "Suco de uva natural sem acúcar feito com a fruta",
                            Name = "Suco de uva",
                            Popular = false,
                            Price = 13m,
                            Stock = 10,
                            UrlImage = "suco_uva1.jpeg"
                        },
                        new
                        {
                            Id = 16,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 4,
                            Details = "Água mineral natural fresquinha",
                            Name = "Água",
                            Popular = false,
                            Price = 5m,
                            Stock = 10,
                            UrlImage = "agua_mineral1.jpeg"
                        },
                        new
                        {
                            Id = 17,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 6,
                            Details = "Cookies de Chocolate com pedaços de chocolate",
                            Name = "Cookies de chocolate",
                            Popular = true,
                            Price = 8m,
                            Stock = 10,
                            UrlImage = "cookie1.jpeg"
                        },
                        new
                        {
                            Id = 18,
                            Available = true,
                            BestSeller = true,
                            CategoryId = 6,
                            Details = "Cookies de baunilha saborosos e crocantes",
                            Name = "Cookies de Baunilha",
                            Popular = false,
                            Price = 8m,
                            Stock = 13,
                            UrlImage = "cookie2.jpeg"
                        },
                        new
                        {
                            Id = 19,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 6,
                            Details = "Torta suíca com creme e camadas de doce de leite",
                            Name = "Torta Suíca",
                            Popular = true,
                            Price = 10m,
                            Stock = 10,
                            UrlImage = "torta_suica1.jpeg"
                        });
                });

            modelBuilder.Entity("APIeCommerce.Entities.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(12,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("APIeCommerce.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UrlImage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APIeCommerce.Entities.Order", b =>
                {
                    b.HasOne("APIeCommerce.Entities.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APIeCommerce.Entities.OrderDetail", b =>
                {
                    b.HasOne("APIeCommerce.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIeCommerce.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("APIeCommerce.Entities.Product", b =>
                {
                    b.HasOne("APIeCommerce.Entities.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APIeCommerce.Entities.ShoppingCartItem", b =>
                {
                    b.HasOne("APIeCommerce.Entities.Product", null)
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APIeCommerce.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("APIeCommerce.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("APIeCommerce.Entities.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ShoppingCartItems");
                });

            modelBuilder.Entity("APIeCommerce.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
