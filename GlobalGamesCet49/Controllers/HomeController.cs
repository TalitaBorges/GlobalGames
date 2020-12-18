using GlobalGamesCet49.Dados;
using GlobalGamesCet49.Dados.Entidades;
using GlobalGamesCet49.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalGamesCet49.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {

            return View();
        }

        public IActionResult Servicos()

        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Mensagem")] ContactoOrcamento ContactoOrcamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ContactoOrcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ContactoOrcamento);
        }

        
        public IActionResult Inscricoes()

        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Apelido,Morada,Localidade,CartaoCidadao,DataNascimento")] Jogador Jogador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Jogador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Jogador);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        private bool ClienteExists(int id)
        {
            return _context.Jogador.Any(e => e.Id == id);
        }
    }

}

