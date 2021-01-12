using GlobalGamesCet49.Dados;
using GlobalGamesCet49.Dados.Entidades;
using GlobalGamesCet49.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;
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
        public async Task<IActionResult> Inscricoes([Bind("Id,Nome,Apelido,Morada,Localidade,CartaoCidadao,DataNascimento,ImageFile")] InscricoesViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\FotoJogador",
                        view.ImageFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/FotoJogador/{view.ImageFile.FileName}";

                }

                var Jogador = this.ToJogador(view, path);



                _context.Add(Jogador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }

            return View(view);
        }


        private Jogador ToJogador(InscricoesViewModel view, string path)
        {
            return new Jogador
            {
                Id = view.Id,
                ImageURL = path,
                Nome = view.Nome,
                Apelido = view.Apelido,
                Morada = view.Morada,
                Localidade = view.Localidade,
                CartaoCidadao = view.CartaoCidadao,
                DataNascimento = view.DataNascimento

            };
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        private bool JogadorExists(int id)
        {
            return _context.Jogador.Any(e => e.Id == id);
        }
    }

}

