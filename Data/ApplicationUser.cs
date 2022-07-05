using Microsoft.AspNetCore.Identity;
using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Nome { get; set; }
        [PersonalData]
        public string Sobrenome { get; set; }
        [PersonalData]
        public string Sobremim { get; set; }
        [PersonalData]
        public string FacebookLink { get; set; }
        [PersonalData]
        public string TwitterLink { get; set; }
        [PersonalData]
        public ICollection<ReceitaModel> ReceitaModels { get; set; }
        [PersonalData]
        public ICollection<FavoritoModel> FavoritoModels { get; set; }
    }
}
