using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usitec_Usinagem.Data;
using Usitec_Usinagem.Models;

namespace Usitec_Usinagem.Controllers
{
    public class ContaController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public ContaController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            
        }
        public IActionResult NovaConta()
        {
            return View(new ContaViewModel());
        }

        [HttpPost]
        public IActionResult CriarConta(ContaViewModel contaViewModel)
        {
            if (contaViewModel.Senha == null)
            {
                ModelState.AddModelError("Senha", "A senha não pode ser nula.");
            }

            if (contaViewModel.NomeUsuario == null)
            {
                ModelState.AddModelError("NomeUsuario", "O nome de usuário não pode ser nulo.");
            }

            if(contaViewModel.Senha != contaViewModel.ConfirmarSenha)
            {
                ModelState.AddModelError("confirmarSenha", "A senha e a confirmação de senha não correspondem.");
            }

            
            if (ModelState.IsValid)
            {
               
                var usuario = new Usuario
                {
                    NomeUsuario = contaViewModel.NomeUsuario,
                    Senha = contaViewModel.Senha
                };

                                
                if (usuario != null)
                {
                    _applicationDbContext.Usuarios.Add(usuario);
                    _applicationDbContext.SaveChanges();

                    TempData["MensagemSucesso"] = "Nova conta criada com sucesso!";
                    return RedirectToAction("Login", new { NomeUsuario = contaViewModel.NomeUsuario });
                }
            }
            else
            {
                return View("NovaConta", contaViewModel);
            }

            return View("NovaConta", contaViewModel);
        }

        public IActionResult Login(string nomeUsuario)
        {
            var loginViewModel = new LoginViewModel { NomeUsuario = nomeUsuario };
            return View("~/Views/PaginaLogin/Login.cshtml", loginViewModel);
        }
    }
}
