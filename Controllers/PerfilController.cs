using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteMVC.Data;
using SiteMVC.Models;
using SiteMVC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Controllers
{
    public class PerfilController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public PerfilController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detalhes(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuar {userName} Não encontrado ";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;

            var model = new PerfilDTO    
            {
                Email = user.Email,
                UserName = user.UserName,
                Nome = user.Nome,
                Sobrenome = user.Sobrenome,
                Sobremim = user.Sobremim,
                FacebookLink = user.FacebookLink,
                TwitterLink = user.TwitterLink
            };

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Receitas(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usario {userName} Não encontrado";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;

            var receitas = _context.ReceitasModels
                .Include(x => x.ReceitaInfoModel)
                .Include(x => x.Autor)
                .Where(x => x.AutorId == user.Id);

            return View(receitas);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Favoritos(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuario {userName} Não encontrado";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;

            var receitas = _context.UsuarioFavoritasReceitas
                .Where(x => x.UserId == user.Id)
                .Include(x => x.ReceitaModel)
                .ThenInclude(x => x.Autor)
                .Include(x => x.ReceitaModel)
                .ThenInclude(x => x.ReceitaInfoModel)
                .Select(x => x.ReceitaModel);

            return View(receitas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarFavorito(ReceitaModel model, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuario {userName} não encontrado";
                return View("NotFound");
            }

            var favoritoModel = new FavoritoModel
            {
                UserId = user.Id,
                ReceitaId = model.Id
            };

            _context.UsuarioFavoritasReceitas.Remove(favoritoModel);
            _context.SaveChanges();

            return RedirectToAction("Favoritos", new { userName = user.UserName });
        }


    }
}
