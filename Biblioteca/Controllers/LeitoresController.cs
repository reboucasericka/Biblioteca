using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Biblioteca.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.Controllers
{
    [Authorize]
    public class LeitoresController : Controller
    {
        private readonly UserManager<Leitor> _userManager;
        private readonly SignInManager<Leitor> _signInManager;

        public LeitoresController(UserManager<Leitor> userManager, SignInManager<Leitor> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Leitores/Perfil
        public async Task<IActionResult> Perfil()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            return View(user);
        }

        // POST: Leitores/Perfil
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Perfil(Leitor leitorAtualizado)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            user.Nome = leitorAtualizado.Nome;
            user.FotoPerfilUrl = leitorAtualizado.FotoPerfilUrl;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Perfil));
        }

        // GET: Leitores/Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
