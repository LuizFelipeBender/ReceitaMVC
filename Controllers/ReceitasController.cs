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
using static SiteMVC.Models.Enums;

namespace SiteMVC.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReceitasController(ILogger<HomeController> logger, ApplicationDbContext context, IWebHostEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index(TipoDeReceita? tipoReceita)
        {
            IEnumerable<ReceitaModel> receitas = _context.ReceitasModels
                .Include(x => x.ReceitaInfoModel)
                .Include(x => x.Autor);

            if (tipoReceita != null && tipoReceita != TipoDeReceita.Nenhuma)
            {
                receitas = _context.ReceitasModels
                    .Where(x => x.TipoDeReceita == tipoReceita)
                    .Include(x => x.ReceitaInfoModel)
                    .Include(x => x.Autor);
                return View(receitas);
            }

            return View(receitas);
        }

        [HttpGet("Receitas/Receita/{id?}/{name?}")]
        [AllowAnonymous]
        public async Task<IActionResult> Detalhes(int? id)
        {
            ReceitaModel receita = GetReceita(id);
            
            if (receita == null) return ErrorStatusCode404(id);
            ViewBag.FavoritoSalvo = false;

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var favoritos = _context.UsuarioFavoritasReceitas.Where(x => x.UserId == user.Id);

                foreach (var favorito in favoritos)
                {
                    if (favorito.ReceitaId == id) ViewBag.FavoritoSalvo = true;
                }
            }

            return View(receita);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            ReceitaModel receita = GetReceita(id);

            if (receita == null) return ErrorStatusCode404(id);

            var receitasEditaViewModel = new ReceitasEditaDTO
            {
                ReceitaModel = receita
            };
            
            return View(receitasEditaViewModel);
        }

        private IActionResult ErrorStatusCode404(int? id)
        {
            try
            {
                Response.StatusCode = 404;
                return View("ReceitaNotFound", id.Value);
            }
            catch (Exception)
            {
                return Error();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ReceitasEditaDTO receitasEditaViewModel)
        {
            if (ModelState.IsValid)
            {
                var receitaModel = receitasEditaViewModel.ReceitaModel;
                if (receitaModel.ReceitaIngredienteModels != null)
                {
                    foreach (var receitaIngredienteModel in receitaModel.ReceitaIngredienteModels)
                    {
                        IngredienteModel existeIngrediente = _context.IngredientesModels
                            .FirstOrDefault(x => x.Ingrediente == receitaIngredienteModel.IngredientsModel.Ingrediente);
                        if (existeIngrediente != null) receitaIngredienteModel.IngredientsModel = existeIngrediente;
                    }
                }

                ReceitaModel receita = GetReceita(receitaModel.Id);
                receita.NomeReceita = receitaModel.NomeReceita;
                receita.ReceitaDescricao = receitaModel.ReceitaDescricao;
                receita.TipoDeReceita = receitaModel.TipoDeReceita;
                receita.ReceitaIngredienteModels = receitaModel.ReceitaIngredienteModels;
                receita.InstrucaoModels = receitaModel.InstrucaoModels;
                receita.AlteradoData = DateTime.Now;

                string FileName = null;
                if (receitasEditaViewModel.Foto != null)
                {
                    if (receitaModel.ReceitaInfoModel.FotoPath != null)
                    {
                        DeleteOldPhotoPath(receitaModel);
                    }

                    var imageFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "uploadedImages");
                    FileName = $"{Guid.NewGuid()}_{receitasEditaViewModel.Foto.FileName}";
                    var path = Path.Combine(imageFolder, FileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        receitasEditaViewModel.Foto.CopyTo(fileStream);
                    }
                    receitaModel.ReceitaInfoModel.FotoPath = FileName;
                }
                receita.ReceitaInfoModel = receitaModel.ReceitaInfoModel;

                _context.Update(receita);
                _context.SaveChanges();
                return RedirectToAction("Detalhes", new { id = receita.Id });
            }

            return View(receitasEditaViewModel.ReceitaModel);
        }

        private void DeleteOldPhotoPath(ReceitaModel receitaModel)
        {
            var oldPhotoPath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "uploadedImages",
                receitaModel.ReceitaInfoModel.FotoPath);
            System.IO.File.Delete(oldPhotoPath);
        }

        private ReceitaModel GetReceita(int? id)
        {
            ReceitaModel receita = _context.ReceitasModels  
                .Include(x => x.ReceitaIngredienteModels)
                .ThenInclude(x => x.IngredientsModel)
                .Include(x => x.InstrucaoModels)
                .Include(x => x.ReceitaInfoModel)
                .Include(x => x.Autor)
                .FirstOrDefault(x => x.Id == id);

            return receita;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int? id)
        {
            ReceitaModel receitaModel = GetReceita(id);

            if (receitaModel == null) return ErrorStatusCode404(id);

        
            if (receitaModel.ReceitaInfoModel != null && receitaModel.ReceitaInfoModel.FotoPath != null)
            {
                DeleteOldPhotoPath(receitaModel);
            }

            _context.Remove(receitaModel);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Pesquisar(string nome)
        {
            IEnumerable<ReceitaModel> receitas = _context.ReceitasModels
                .Where(x => x.NomeReceita.Contains(nome))
                .Include(x => x.ReceitaInfoModel)
                .Include(x => x.Autor);
            return View(receitas);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Favoritos(int receitaId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Não foi possível carregar o usuário com o ID '{_userManager.GetUserId(User)}'.";
                return View("NotFound");
            }

            var favoritoModel = new FavoritoModel
            {
                UserId = user.Id,
                ReceitaId = receitaId
            };

            _context.UsuarioFavoritasReceitas.Add(favoritoModel);
            _context.SaveChanges();

            return RedirectToAction("Detalhes", new { id = receitaId });
        }
    }
}
