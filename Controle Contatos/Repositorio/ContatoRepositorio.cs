using Controle_Contatos.Data;
using Controle_Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Contatos.Repositorio
{
   
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);

        }

        public List<ContatoModel> BuscarTodos(int usuarioId)
        {
            return _bancoContext.Contatos.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoBD = ListarPorId(contato.Id);

            if (contatoBD == null) throw new System.Exception("Houve um erro na atualização do contato");

            contatoBD.Nome = contato.Nome;
            contatoBD.Email = contato.Email;
            contatoBD.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoBD);
            _bancoContext.SaveChanges();

            return contatoBD;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoBD = ListarPorId(id);

            if (contatoBD == null) throw new System.Exception("Houve um erro na atualização do contato");

            _bancoContext.Contatos.Remove(contatoBD);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
