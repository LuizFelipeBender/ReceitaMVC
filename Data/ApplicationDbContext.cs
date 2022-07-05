using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<ReceitaModel> ReceitasModels { get; set; }
        public DbSet<IngredienteModel> IngredientesModels { get; set; } 
        public DbSet<ReceitaIngredienteModel> ReceitaIngredienteModels { get; set; }
        public DbSet<InstrucaoModel> instrucaoModels { get; set; }
        public DbSet<ReceitaInfoModel> ReceitaInfoModels { get; set; }
        public DbSet<FavoritoModel> UsuarioFavoritasReceitas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
