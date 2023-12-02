using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Usitec_Usinagem.Models
{
    public class ContaViewModel
    {
        [Required(ErrorMessage = "O campo Nome de Usuário é obrigatório.")]
        public string NomeUsuario { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O campo Confirmar Senha é obrigatório.")]
        [Compare("Senha", ErrorMessage = "A senha e a confirmação de senha não correspondem.")]
        public string ConfirmarSenha { get; set; }
    }
}
