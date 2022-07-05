using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiteMVC.Data;
using SiteMVC.Models;
using SiteMVC.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IWebHostEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<ReceitaModel> receitaDestaque = _context.ReceitasModels
                .OrderBy(x => Guid.NewGuid())
                .Include(x => x.ReceitaInfoModel)
                .Include(x => x.Autor)
                .Take(3).ToList();

       
            var model = new HomeIndexDTO
            {
                ReceitasDestaque = receitaDestaque,
            };

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                List<ReceitaModel> favoritos = _context.UsuarioFavoritasReceitas
                .Include(x => x.ReceitaModel.ReceitaInfoModel)
                .Where(x => x.UserId == user.Id)
                .Select(x => x.ReceitaModel).ToList();
                model.Favoritos = favoritos;
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HomeCriaDTO homeCriaDTO)
        {
          
                var receitaModel = homeCriaDTO.ReceitaModel;
                var ingredientModels = homeCriaDTO.IngredienteModels;
                var receitaIngredientesModels = homeCriaDTO.ReceitaIngredienteModels;
                var instrucaoModels = homeCriaDTO.InstrucaoModels;

                if (ingredientModels != null)
                {
                    var index = 0;
                    foreach (var ingredienteModel in ingredientModels)
                    {
                        // Checa se o Ingrediente existeIngrediente
                        IngredienteModel existeIngrediente =_context.IngredientesModels.FirstOrDefault(x => x.Ingrediente == ingredienteModel.Ingrediente);
                        if (existeIngrediente != null)
                        {
                            receitaIngredientesModels[index].IngredienteId = existeIngrediente.Id;
                        }
                        else
                        {
                            receitaIngredientesModels[index].IngredientsModel = ingredienteModel;
                        }
                        index++;
                    }
                }

                string FileName = null;
                if (homeCriaDTO.Foto != null)
                {
                    var imageFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "uploadedImages");
                    FileName = $"{Guid.NewGuid()}_{homeCriaDTO.Foto.FileName}";
                    var path = Path.Combine(imageFolder, FileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        homeCriaDTO.Foto.CopyTo(fileStream);
                    }
                    receitaModel.ReceitaInfoModel.FotoPath = FileName; 
                }

                var userId = _userManager.GetUserId(User);

                var novaReceita = new ReceitaModel
                {
                    NomeReceita = receitaModel.NomeReceita,
                    ReceitaDescricao = receitaModel.ReceitaDescricao,
                    TipoDeReceita = receitaModel.TipoDeReceita,
                    DataDeCriacao = receitaModel.DataDeCriacao,
                    ReceitaIngredienteModels = receitaIngredientesModels,
                    InstrucaoModels = instrucaoModels,
                    ReceitaInfoModel = receitaModel.ReceitaInfoModel,
                    AutorId = userId
                };

                _context.Add(novaReceita);
                _context.SaveChanges();
                return RedirectToAction("Index");
            

        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
