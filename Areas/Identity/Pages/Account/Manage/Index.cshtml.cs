using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteMVC.Data;

namespace SiteMVC.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [DataType(DataType.Text)]
            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Sobrenome")]
            public string Sobrenome { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Sobre mim")]
            public string Sobremim { get; set; }


            [DataType(DataType.Text)]
            [Display(Name = "Facebook")]
            public string FacebookLink { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Twitter")]
            public string TwitterLink { get; set; }

            [Display(Name = "User name")]
            public string UserName { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Nome = user.Nome,
                Sobrenome = user.Sobrenome,
                Sobremim = user.Sobremim,
                FacebookLink = user.FacebookLink,
                TwitterLink = user.TwitterLink,
                UserName = user.UserName
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userName = await _userManager.GetUserNameAsync(user);
            if (Input.UserName != userName)
            {
                var setUserNameResult = await _userManager.SetUserNameAsync(user, Input.UserName);
                if (!setUserNameResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set user name.";
                    return RedirectToPage();
                }
            }

            if (Input.Nome != user.Nome) user.Nome = Input.Nome;
            if (Input.Sobrenome != user.Sobrenome) user.Sobrenome = Input.Sobrenome;
            if (Input.Sobremim != user.Sobremim) user.Sobremim = Input.Sobremim;
            if (Input.FacebookLink != user.FacebookLink) user.FacebookLink = Input.FacebookLink;
            if (Input.TwitterLink != user.TwitterLink) user.TwitterLink = Input.TwitterLink;

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
