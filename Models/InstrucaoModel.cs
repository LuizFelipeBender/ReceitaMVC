using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Models
{
    public class InstrucaoModel
    {
        public int Id { get; set; }
        public int ReceitaId { get; set; }
       
        [DisplayName("Instrucao")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "O campo {0} deve conter no minimo {1} e no máximo {2}")]
        public string Instrucao { get; set; }
        public ReceitaModel ReceitaModel { get; set; }
    }
}
