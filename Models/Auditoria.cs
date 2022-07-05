using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Models
{
    public class Auditoria
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id {get;set;}

        [Column("Detalhes")]
        [Display(Name = "Detalhes da alteracao")]
        public string Detalhes {get;set;}

        [Column("EmailDeUsuario")]
        [Display(Name = "Email do usurio")]
        public string EmailDeUsuario {get;set;}
        
    }
}