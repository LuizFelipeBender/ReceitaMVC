using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiteMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceitaIngredienteModel>()
                .HasKey(x => new { x.ReceitaId, x.IngredienteId });
            modelBuilder.Entity<ReceitaIngredienteModel>()
                .HasOne(x => x.ReceitaModel)
                .WithMany(x => x.ReceitaIngredienteModels)
                .HasForeignKey(x => x.ReceitaId);
            modelBuilder.Entity<ReceitaIngredienteModel>()
                .HasOne(x => x.IngredientsModel)
                .WithMany(x => x.ReceitaIngredienteModels)
                .HasForeignKey(x => x.IngredienteId);

            modelBuilder.Entity<InstrucaoModel>()
                .HasOne(x => x.ReceitaModel)
                .WithMany(x => x.InstrucaoModels)
                .HasForeignKey(x => x.ReceitaId);

            modelBuilder.Entity<ReceitaModel>()
                .HasOne(x => x.ReceitaInfoModel)
                .WithOne(x => x.ReceitaModel)
                .HasForeignKey<ReceitaInfoModel>(x => x.ReceitaId);

            modelBuilder.Entity<ReceitaModel>()
                .HasOne(x => x.Autor)
                .WithMany(x => x.ReceitaModels)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey(x => x.AutorId);

            modelBuilder.Entity<FavoritoModel>()
                .HasKey(x => new { x.ReceitaId, x.UserId });
            modelBuilder.Entity<FavoritoModel>()
                .HasOne(x => x.ApplicationUser)
                .WithMany(x => x.FavoritoModels)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<FavoritoModel>()
                .HasOne(x => x.ReceitaModel)
                .WithMany(x => x.FavoritoModels)
                .HasForeignKey(x => x.ReceitaId);
        }     
    }
}