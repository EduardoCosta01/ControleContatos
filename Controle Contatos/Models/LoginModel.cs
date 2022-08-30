using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Contatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }
    }
}
