using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Biblioteca.Controllers
{
    public class ReservasController : Controller
    {
        private readonly BibliotecaContext _context;
        private readonly UserManager<Leitor> _userManager;

        public ReservasController(BibliotecaContext context, UserManager<Leitor> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var reservas = _context.Reservas
                .Include(r => r.Livro)
                .Include(r => r.Leitor);

            return View(await reservas.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var reserva = await _context.Reservas
                .Include(r => r.Livro)
                .Include(r => r.Leitor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reserva == null) return NotFound();

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["Livros"] = _context.Livros.Where(l => l.IsAvailable).ToList();
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int livroId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var reserva = new Reserva
            {
                LivroId = livroId,
                LeitorId = user.Id,
                DataReserva = System.DateTime.Now,
                Ativa = true
            };

            _context.Add(reserva);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Reservas/Cancelar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancelar(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return NotFound();

            reserva.Ativa = false;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}