using Controle_Contatos.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Contatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Digite o Login do usuário")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Digite o E-mail do usuário")]
        [EmailAddress(ErrorMessage = "O E-mail informado não é valido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
    }
}
