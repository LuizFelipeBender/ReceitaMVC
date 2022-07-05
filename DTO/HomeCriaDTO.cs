using Microsoft.AspNetCore.Http;
using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.DTO
{
    public class HomeCriaDTO
    {
        public ReceitaModel ReceitaModel { get; set; }
        public List<ReceitaIngredienteModel> ReceitaIngredienteModels { get; set; }
        public List<IngredienteModel> IngredienteModels { get; set; }
        public List<InstrucaoModel> InstrucaoModels { get; set; }
        public IFormFile Foto { get; set; }
    }
}
