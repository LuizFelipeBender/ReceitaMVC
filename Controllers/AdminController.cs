using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteMVC.Data;
using SiteMVC.Models;
using SiteMVC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult ListaUsuarios()
        {
            var users = _userManager.Users;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditarUsuario(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuário com código = {id} não pode ser encontrado";
                return View("Não encontrado");
            }

            var model = new EditaUsarioDTO
            {
                Id = user.Id,
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarUsuario(EditaUsarioDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuário com código = {model.Id} não pode ser encontrado";
                return View("Not found erro 404");
            }

            if (model.UserName != user.UserName) user.UserName = model.UserName;
            if (model.Nome != user.Nome) user.Nome = model.Nome;
            if (model.Sobrenome != user.Sobrenome) user.Sobrenome = model.Sobrenome;
            if (model.Sobremim != user.Sobremim) user.Sobremim = model.Sobremim;
            if (model.FacebookLink != user.FacebookLink) user.FacebookLink = model.FacebookLink;
            if (model.TwitterLink != user.TwitterLink) user.TwitterLink = model.TwitterLink;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return RedirectToAction("ListaUsuarios");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("Not found erro 404", error.Description);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarUsuario(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuário com código = {id} não pode ser encontrado";
                return View("Not found erro 404");
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded) return RedirectToAction("ListaUsuarios");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("ListaUsuarios");
        }

        public IActionResult ListaIngredientes()
        {
            var adminIngredienteViewModel = new AdminIngredienteDTO();
            adminIngredienteViewModel.IngredienteModels = _context.IngredientesModels;

            return View(adminIngredienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddIngrediente(AdminIngredienteDTO model)
        {
            if (ModelState.IsValid)
            {
                _context.IngredientesModels.Add(model.IngredienteModel);
                _context.SaveChanges();
                return RedirectToAction("ListaIngredientes");
            }

            return View("ListaIngredientes");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarIngrediente(int? id)
        {
            IngredienteModel ingredienteModel = _context.IngredientesModels.FirstOrDefault(x => x.Id == id);

            _context.IngredientesModels.Remove(ingredienteModel);
            _context.SaveChanges();

            return RedirectToAction("ListaIngredientes");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarIngrediente(IngredienteModel model)
        {
            if (ModelState.IsValid)
            {
                IngredienteModel ingrediente = _context.IngredientesModels.FirstOrDefault(x => x.Id == model.Id);
                ingrediente.Ingrediente = model.Ingrediente;

                _context.IngredientesModels.Update(ingrediente);
                _context.SaveChanges();
                return RedirectToAction("ListaIngredientes");
            }

            return View("ListaIngredientes");
        }
    }
}
