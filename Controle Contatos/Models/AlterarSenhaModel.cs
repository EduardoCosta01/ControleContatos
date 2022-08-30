using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Contatos.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite sua senha atual")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Digite sua nova senha")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme sua nova senha")]
        [Compare("NovaSenha", ErrorMessage ="A senha não confere")]
        public string ConfirmarNovaSenha { get; set; }

    }
}
