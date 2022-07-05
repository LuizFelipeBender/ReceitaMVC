using SiteMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.DTO
{
    public class PerfilDTO
    {
        public string Id { get; set; }
        [Required (ErrorMessage ="Favor prencher o Campo e-mail")]
        [EmailAddress]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "O campo {0} deve conter no minimo {1} e no máximo {2}")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nome de usuario")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "O campo {0} deve conter no minimo {1} e no máximo {2}")]
        
        public string UserName { get; set; }
        [Display(Name = "Nome")]
         [StringLength(60, MinimumLength = 3, ErrorMessage = "O campo {0} deve conter no minimo {1} e no máximo {2}")]

        public string Nome { get; set; }
        [Display(Name = "Sobrenome")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "O campo {0} deve conter no minimo {1} e no máximo {2}")]

        public string Sobrenome { get; set; }
        [Display(Name = "Sobre mim")]

        public string Sobremim { get; set; }
        [Display(Name = "Facebook")]

        public string FacebookLink { get; set; }
        [Display(Name = "Twitter")]
        public string TwitterLink { get; set; }
    }
}
