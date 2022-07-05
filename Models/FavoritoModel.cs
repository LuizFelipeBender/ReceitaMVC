using SiteMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Models
{
    public class FavoritoModel
    {
        public string UserId { get; set; }
        public int ReceitaId { get; set; }
        public ReceitaModel ReceitaModel { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
