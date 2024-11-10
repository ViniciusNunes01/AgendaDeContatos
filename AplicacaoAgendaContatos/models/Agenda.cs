namespace Models.Agenda;

using System.Collections.Generic;
using System.Linq;
using Models.Cadastros.Contatos;

public class Agenda {

        private List<Contato> _contatos;

        public Agenda() {

            _contatos = new List<Contato>();
        }

        public void AdicionarContato(Contato contato) {

            _contatos.Add(contato);
        }

        public void EditarContato(int idContato, Contato contatoAtualizado) {

            var contatoExistente = _contatos.FirstOrDefault(c => c.IdContato == idContato);

            if (contatoExistente != null) {

                contatoExistente.Nome = contatoAtualizado.Nome;
                contatoExistente.Sobrenome = contatoAtualizado.Sobrenome;
                contatoExistente.Empresa = contatoAtualizado.Empresa;
                contatoExistente.Telefones = contatoAtualizado.Telefones;
                contatoExistente.Emails = contatoAtualizado.Emails;
                contatoExistente.DatasImportantes = contatoAtualizado.DatasImportantes;
            }
        }

        public void RemoverContato(int idContato) {

            var contato = _contatos.FirstOrDefault(c => c.IdContato == idContato);

            if (contato != null) {

                _contatos.Remove(contato);
            }
        }

        public List<Contato> ListarContatos() {

            return new List<Contato>(_contatos);    
        }

        public Contato? ObterContatoPorId(int idContato) {
            
            return _contatos.FirstOrDefault(c => c.IdContato == idContato);
        }
        
    }