using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Usitec_Usinagem.Controllers
{
    public class PaginaInicialController : Controller
    {
        private readonly ILogger<PaginaInicialController> _logger;

        public PaginaInicialController(ILogger<PaginaInicialController> logger)
        {
            _logger = logger;
        }
        public IActionResult Inicio()
        {
            _logger.LogInformation("Inicio da Action Inicio");
            return View();
        }
    }
}
