using Microsoft.AspNetCore.Http;
using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.DTO
{
    public class ReceitasEditaDTO
    {
        public ReceitaModel ReceitaModel { get; set; }
        public IFormFile Foto { get; set; }
    }
}
