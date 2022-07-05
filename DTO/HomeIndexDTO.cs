using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.DTO
{
    public class HomeIndexDTO
    {
        public List<ReceitaModel> ReceitasDestaque { get; set; } = new List<ReceitaModel>();
        public List<ReceitaModel> Favoritos { get; set; } = new List<ReceitaModel>();
    }
}
