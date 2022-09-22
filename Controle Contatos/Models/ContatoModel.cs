using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Contatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do contato")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Digite o E-mail do contato")]
        [EmailAddress(ErrorMessage ="O E-mail informado não é valido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage ="O celular informado não é valido")]
        public string Celular { get; set; }

        public int? UsuarioId { get; set; }

        public UsuarioModel Usuario { get; set; }


    }
}
