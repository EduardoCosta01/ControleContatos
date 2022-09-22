using Controle_Contatos.Enums;
using Controle_Contatos.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Contatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Digite o Login do usuário")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Digite o E-mail do usuário")]
        [EmailAddress(ErrorMessage = "O E-mail informado não é valido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Digite o Senha do usuário")]
        public string Senha { get; set; }


        public DateTime DataCadastro { get; set; }


        public DateTime? DataAtualizacao { get; set; }

        public virtual List<ContatoModel> Contatos { get; set; }


        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }

        public bool SenhaValida (string senha)
        {
            return Senha == senha.GerarHosh();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHosh();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHosh();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHosh();
            return novaSenha;
        }


    }
}
