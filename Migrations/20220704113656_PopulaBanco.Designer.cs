// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteMVC.Data;

namespace SiteMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220704113656_PopulaBanco")]
    partial class PopulaBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SiteMVC.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FacebookLink")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Sobremim")
                        .HasColumnType("longtext");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("longtext");

                    b.Property<string>("TwitterLink")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SiteMVC.Models.FavoritoModel", b =>
                {
                    b.Property<int>("ReceitaId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ReceitaId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsuarioFavoritasReceitas");
                });

            modelBuilder.Entity("SiteMVC.Models.IngredienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ingrediente")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("IngredientesModels");
                });

            modelBuilder.Entity("SiteMVC.Models.InstrucaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Instrucao")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("ReceitaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceitaId");

                    b.ToTable("instrucaoModels");
                });

            modelBuilder.Entity("SiteMVC.Models.ReceitaInfoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FotoPath")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("ReceitaId")
                        .HasColumnType("int");

                    b.Property<int>("Rende")
                        .HasColumnType("int");

                    b.Property<int>("ServePessoa")
                        .HasColumnType("int");

                    b.Property<int>("TempCozinhamento")
                        .HasColumnType("int");

                    b.Property<int>("TempoPrep")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceitaId")
                        .IsUnique();

                    b.ToTable("ReceitaInfoModels");
                });

            modelBuilder.Entity("SiteMVC.Models.ReceitaIngredienteModel", b =>
                {
                    b.Property<int>("ReceitaId")
                        .HasColumnType("int");

                    b.Property<int>("IngredienteId")
                        .HasColumnType("int");

                    b.Property<string>("IngredienteUnidade")
                        .HasColumnType("longtext");

                    b.Property<int>("QuantidadeIngrendiente")
                        .HasColumnType("int");

                    b.HasKey("ReceitaId", "IngredienteId");

                    b.HasIndex("IngredienteId");

                    b.ToTable("ReceitaIngredienteModels");
                });

            modelBuilder.Entity("SiteMVC.Models.ReceitaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("AlteradoData")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("AutorId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("DataDeCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeReceita")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ReceitaDescricao")
                        .HasColumnType("longtext");

                    b.Property<int>("TipoDeReceita")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("ReceitasModels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SiteMVC.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SiteMVC.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiteMVC.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SiteMVC.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SiteMVC.Models.FavoritoModel", b =>
                {
                    b.HasOne("SiteMVC.Models.ReceitaModel", "ReceitaModel")
                        .WithMany("FavoritoModels")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiteMVC.Data.ApplicationUser", "ApplicationUser")
                        .WithMany("FavoritoModels")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("ReceitaModel");
                });

            modelBuilder.Entity("SiteMVC.Models.InstrucaoModel", b =>
                {
                    b.HasOne("SiteMVC.Models.ReceitaModel", "ReceitaModel")
                        .WithMany("InstrucaoModels")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReceitaModel");
                });

            modelBuilder.Entity("SiteMVC.Models.ReceitaInfoModel", b =>
                {
                    b.HasOne("SiteMVC.Models.ReceitaModel", "ReceitaModel")
                        .WithOne("ReceitaInfoModel")
                        .HasForeignKey("SiteMVC.Models.ReceitaInfoModel", "ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReceitaModel");
                });

            modelBuilder.Entity("SiteMVC.Models.ReceitaIngredienteModel", b =>
                {
                    b.HasOne("SiteMVC.Models.IngredienteModel", "IngredientsModel")
                        .WithMany("ReceitaIngredienteModels")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiteMVC.Models.ReceitaModel", "ReceitaModel")
                        .WithMany("ReceitaIngredienteModels")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IngredientsModel");

                    b.Navigation("ReceitaModel");
                });

            modelBuilder.Entity("SiteMVC.Models.ReceitaModel", b =>
                {
                    b.HasOne("SiteMVC.Data.ApplicationUser", "Autor")
                        .WithMany("ReceitaModels")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("SiteMVC.Data.ApplicationUser", b =>
                {
                    b.Navigation("FavoritoModels");

                    b.Navigation("ReceitaModels");
                });

            modelBuilder.Entity("SiteMVC.Models.IngredienteModel", b =>
                {
                    b.Navigation("ReceitaIngredienteModels");
                });

            modelBuilder.Entity("SiteMVC.Models.ReceitaModel", b =>
                {
                    b.Navigation("FavoritoModels");

                    b.Navigation("InstrucaoModels");

                    b.Navigation("ReceitaInfoModel");

                    b.Navigation("ReceitaIngredienteModels");
                });
#pragma warning restore 612, 618
        }
    }
}
