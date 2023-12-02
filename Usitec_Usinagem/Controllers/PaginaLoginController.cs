using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Usitec_Usinagem.Data;
using Usitec_Usinagem.Models;

namespace Usitec_Usinagem.Controllers
{
    public class PaginaLoginController : Controller
    {
        private readonly ILogger<PaginaLoginController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public PaginaLoginController(ILogger<PaginaLoginController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Login()
        {
            Console.WriteLine("Entrou no método LoginViewModel");
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Autenticar(LoginViewModel loginViewModel)
        {
            Console.WriteLine("Entrou no método Autenticar");
            var usuario = _applicationDbContext.Usuarios
                .FirstOrDefault(u => u.NomeUsuario == loginViewModel.NomeUsuario && u.Senha == loginViewModel.Senha);

            if (usuario != null)
            {
                Console.WriteLine("Autenticação bem-sucedida. Redirecionando para Inicio");
                return RedirectToAction("Inicio", "PaginaInicial");
            }
            else
            {
                Console.WriteLine("Autenticação falhou. Retornando para a página de Login");
                ModelState.AddModelError(string.Empty, "Nome de usuário ou senha inválidos.");
                return View("Login", loginViewModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



