using AspNetIdentityCore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AspNetIdentityCore.Pages
{
    public class LoginModel : PageModel
    {

        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]        
        public Login Model { get; set; }

       

        public LoginModel(SignInManager<IdentityUser>signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnurl=null)
        {
            if (ModelState.IsValid)
            {

                var IdentityResult = await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);

                if (IdentityResult.Succeeded)
                {
                    if(returnurl==null || returnurl=="/")
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction(returnurl);
                    }

                }
                ModelState.AddModelError("","Username oder Password incorrect.");


            }
            return Page();


        }
    }
}
