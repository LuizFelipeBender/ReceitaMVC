using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.DTO
{
    public class AdminIngredienteDTO
    {
        public IngredienteModel IngredienteModel { get; set; }
        public IEnumerable<IngredienteModel> IngredienteModels { get; set; }
    }
}
