using Controle_Contatos.Data;
using Controle_Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Contatos.Repositorio
{
   
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel BuscaPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);

        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioBD = ListarPorId(usuario.Id);

            if (usuarioBD == null) throw new System.Exception("Houve um erro na atualização do usuário");

            usuarioBD.Nome = usuario.Nome;
            usuarioBD.Email = usuario.Email;
            usuarioBD.Login = usuario.Login;
            usuarioBD.Perfil = usuario.Perfil;
            usuarioBD.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioBD);
            _bancoContext.SaveChanges();

            return usuarioBD;
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDB = ListarPorId(alterarSenhaModel.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

            if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere!");

            if(usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha )) throw new Exception("Nova senha deve ser diterente ad senha atual!");

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;

        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioBD = ListarPorId(id);

            if (usuarioBD == null) throw new System.Exception("Houve um erro na atualização do usuário");

            _bancoContext.Usuarios.Remove(usuarioBD);
            _bancoContext.SaveChanges();

            return true;

        }

      
    }
}
