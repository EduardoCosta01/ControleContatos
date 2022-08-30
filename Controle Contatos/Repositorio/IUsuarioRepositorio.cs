using Controle_Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Contatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscaPorLogin(string login);

        UsuarioModel BuscarPorEmailELogin(string email, string login);

        UsuarioModel ListarPorId(int id);

        List<UsuarioModel> BuscarTodos();

        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);

        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel); 

        bool Apagar(int id);
    }
}
