using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Models
{
    public class ReceitaIngredienteModel
    {
        public int ReceitaId { get; set; }
        public int IngredienteId { get; set; }
        public ReceitaModel ReceitaModel { get; set; }
        public IngredienteModel IngredientsModel { get; set; }
       

        public string IngredienteUnidade { get; set; }   
        public int QuantidadeIngrendiente { get; set; }

    }
}
