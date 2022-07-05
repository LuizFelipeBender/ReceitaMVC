using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Models
{
    public class ReceitaInfoModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Render")]
        [Range(1, 999, ErrorMessage = "a receita deve {0} pelo menos no minimo {1} porção e no máximo {2} porção, favor prencha o campo da forma correta")]
        [Required(ErrorMessage = "Favor prencher o campo {0}")]

        public int Rende { get; set; }
        [DisplayName("Tempo de preparação dos ingredientes")]
        [Range(0, 999, ErrorMessage = "O  {0} deve estar entre {1} minuto e no máximo {2} minutos, favor prencha o campo da forma correta")]
        [Required(ErrorMessage = "Favor prencher o campo {0}")]

        public int TempoPrep { get; set; }
        [DisplayName("Tempo total de cozinhamento")]
        [Range(1, 999, ErrorMessage = "O  {0} deve estar entre {1} minuto e no máximo {2} minutos, favor prencha o campo da forma correta")]
        [Required(ErrorMessage = "Favor prencher o campo {0}")]

        public int TempCozinhamento { get; set; }
        
        [DisplayName("Serve:" )]
        [Range(1, 999, ErrorMessage = "A receita deve  servir  no minimo {1} uma pessoa e no máximo {2} pesssoas, favor prencha o campo da forma correta")]
        [Required(ErrorMessage = "Favor prencher o campo {0}")]
        public int ServePessoa { get; set; }

        [DisplayName("Foto da receita")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "O campo {0} deve conter no minimo {1} e no máximo {2}")]
        [Required(ErrorMessage = "Favor prencher o {0}")]
        public string FotoPath { get; set; }
        public int ReceitaId { get; set; }
        public ReceitaModel ReceitaModel { get; set; }
    }
}
