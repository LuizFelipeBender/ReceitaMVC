using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Models
{
    public class IngredienteModel
    {
        public int Id { get; set; }

        [DisplayName("Ingrediente")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O campo {0} deve conter no minimo {1} e no máximo {2}")]
        public string Ingrediente { get; set; }
        public ICollection<ReceitaIngredienteModel> ReceitaIngredienteModels { get; set; }
    }
}
