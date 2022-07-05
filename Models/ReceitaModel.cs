using SiteMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static SiteMVC.Models.Enums;

namespace SiteMVC.Models
{
    public class ReceitaModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Nome receita")]
        [Required(ErrorMessage = "   campo {0} pois ele é obrigatório")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} deve conter no minimo {1} e no máximo {2}")]
        public string NomeReceita { get; set; }

        [DisplayName("Descricao")]
        public string ReceitaDescricao { get; set; }


        [DisplayName("Categoria")]
        public TipoDeReceita TipoDeReceita { get; set; }
        [DisplayName("Data de criacao ")]
        public DateTime? DataDeCriacao { get; set; } = DateTime.Now;
        [DisplayName("Data de alteracao")]
        public DateTime? AlteradoData { get; set; }
        public string AutorId { get; set; }
        public ApplicationUser Autor { get; set; }
        public ICollection<ReceitaIngredienteModel> ReceitaIngredienteModels { get; set; }
        public ICollection<InstrucaoModel> InstrucaoModels { get; set; }
        public ReceitaInfoModel ReceitaInfoModel { get; set; }
        public ICollection<FavoritoModel> FavoritoModels { get; set; }
    }
}
