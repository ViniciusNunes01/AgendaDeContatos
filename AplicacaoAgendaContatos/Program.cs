using System;
using System.Collections.Generic;
using Models.Agenda;
using Models.Cadastros.Contatos;
using Utils;
using Utils.Marcadores;

namespace AgendaContatos {

    class Program {

        static void Main(string[] args) {

            var agenda = new Agenda();
            bool sair = false;

            while (!sair) {

                Console.Clear();
                Console.WriteLine("\nA G E N D A    D E     C O N T A T O S");
                Console.WriteLine("\n1. Cadastrar contato");
                Console.WriteLine("2. Visualizar contatos");
                Console.WriteLine("3. Editar contato");
                Console.WriteLine("4. Remover contato");
                Console.WriteLine("5. Sair");
                Console.Write("\nEscolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao) {

                    case "1":
                        var novoContato = CadastrarContato();
                        agenda.AdicionarContato(novoContato);
                        Console.WriteLine("\nContato cadastrado com sucesso!");
                        Pausar();
                        break;
                    case "2":
                        MostrarContatosAgenda(agenda);
                        Pausar();
                        break;
                    case "3":
                        Console.Write("Informe o ID do contato a ser editado: ");
                        int idEditar = int.Parse(Console.ReadLine() ?? "");
                        var contatoAtualizado = CadastrarContato();
                        agenda.EditarContato(idEditar, contatoAtualizado);
                        Console.WriteLine("\nContato editado com sucesso!");
                        Pausar();
                        break;
                    case "4":
                        RemoverContatoAgenda(agenda);
                        Pausar();
                        break;
                    case "5":
                        sair = true;
                        Console.WriteLine("\nFinalizando Programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente.");
                        Pausar();
                        break;
                }
            }
        }

        static void Pausar() {

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static Contato CadastrarContato() {

            Console.Clear();
            Console.WriteLine("\nInforme os dados do contato:");

            var contato = new Contato();

            Console.Write("ID do Contato: ");
            contato.IdContato = int.Parse(Console.ReadLine() ?? "");

            Console.Write("Nome: ");
            contato.Nome = Console.ReadLine();

            Console.Write("Sobrenome: ");
            contato.Sobrenome = Console.ReadLine();

            Console.Write("Empresa: ");
            contato.Empresa = Console.ReadLine();

            contato.Telefones = CadastrarTelefone();
            contato.Emails = CadastrarEmail();
            contato.DatasImportantes = CadastrarDataImportante();

            return contato;
        }

        static List<TelefoneContato> CadastrarTelefone() {

            var telefones = new List<TelefoneContato>();

            Console.Clear();

            Console.WriteLine("Informe os telefones (digite 'sair' para parar):");

            while (true) {

                Console.Write("Número: ");
                var numero = Console.ReadLine();
                if (numero?.ToLower() == "sair") break;

                Console.Write("Marcador (1 - Celular, 2 - Comercial, 3 - Casa, 4 - Principal, 5 - Fax Comercial, 6 - Fax Residencial, 7 - Pager, 8 - Personalizado): ");
                var marcador = (MarcadorTelefone)int.Parse(Console.ReadLine() ?? "");

                telefones.Add(new TelefoneContato { Numero = numero, Marcador = marcador });
            }

            return telefones;
        }

        static List<EmailContato> CadastrarEmail() {

            var emails = new List<EmailContato>();

            Console.Clear();

            Console.WriteLine("Informe os emails (digite 'sair' para parar):");

            while (true) {

                Console.Write("Endereço de Email: ");
                var email = Console.ReadLine();
                if (email?.ToLower() == "sair") break;

                Console.Write("Marcador (1 - Casa, 2 - Pessoal, 3 - Comercial, 4 - Outros, 5 - Personalizado): ");
                var marcador = (MarcadorEmail)int.Parse(Console.ReadLine() ?? "");

                emails.Add(new EmailContato { EnderecoEmail = email, Marcador = marcador });
            }

            return emails;
        }

        static List<DataImportanteContato> CadastrarDataImportante() {

            var datasImportantes = new List<DataImportanteContato>();

            Console.Clear();

            Console.WriteLine("Informe as datas importantes (digite 'sair' para parar):");

            while (true) {

                Console.Write("Data (dd/MM/yyyy): ");
                var dataStr = Console.ReadLine();
                if (dataStr.ToLower() == "sair") break;

                var data = DateTime.ParseExact(dataStr, "dd/MM/yyyy", null);

                Console.Write("Marcador (1 - Aniversário, 2 - Evento, 3 - Data Comemorativa, 4 - Outros, 5 - Personalizado): ");
                var marcador = (MarcadorDataImportante)int.Parse(Console.ReadLine() ?? "");

                datasImportantes.Add(new DataImportanteContato { Data = data, Marcador = marcador });
            }

            return datasImportantes;
        }

        static void MostrarContatosAgenda(Agenda agenda) {

            while (true) {

                var contatos = agenda.ListarContatos();

                Console.Clear();

                if (contatos.Count == 0) {

                    Console.WriteLine("\nNenhum contato cadastrado.");
                    Pausar();
                    return;
                }

                Console.WriteLine("\nLista de Contatos:");
                foreach (var contato in contatos) {

                    Console.WriteLine($"ID: {contato.IdContato}, Nome: {contato.Nome} {contato.Sobrenome}");
                }

                Console.Write("\nDigite o ID do contato para ver os detalhes ou 'sair' para voltar ao menu principal: ");
                var entrada = Console.ReadLine();

                if (entrada?.ToLower() == "sair") {
                    return;
                }

                if (int.TryParse(entrada, out int idContato)) {

                    var contatoSelecionado = agenda.ObterContatoPorId(idContato);
                    if (contatoSelecionado != null) {
                        
                        MostrarDetalhesContato(contatoSelecionado);

                    } else {

                        Console.WriteLine("\nContato não encontrado!");
                        Pausar();
                    }

                } else {

                    Console.WriteLine("\nID inválido!");
                    Pausar();
                }
            }
        }

        static void MostrarDetalhesContato(Contato contato) {

            Console.Clear();
            Console.WriteLine($"\nContato ID: {contato.IdContato}");
            Console.WriteLine($"Nome: {contato.Nome} {contato.Sobrenome}");
            Console.WriteLine($"Empresa: {contato.Empresa}");

            Console.WriteLine("\nTelefones:");
            foreach (var telefone in contato.Telefones) {

                Console.WriteLine($"Número: {telefone.Numero}, Marcador: {telefone.Marcador}");
            }

            Console.WriteLine("\nEmails:");
            foreach (var email in contato.Emails) {

                Console.WriteLine($"Endereço: {email.EnderecoEmail}, Marcador: {email.Marcador}");
            }

            Console.WriteLine("\nDatas Importantes:");
            foreach (var data in contato.DatasImportantes) {

                Console.WriteLine($"Data: {data.Data.ToShortDateString()}, Marcador: {data.Marcador}");
            }

            Pausar();
        }

        static void RemoverContatoAgenda(Agenda agenda) {

            var contatos = agenda.ListarContatos();

            Console.Clear();
            Console.WriteLine("Remover Contato:");

            Console.WriteLine("\nLista de Contatos:");
                foreach (var contato in contatos) {
                    Console.WriteLine($"ID: {contato.IdContato}, Nome: {contato.Nome} {contato.Sobrenome}");
                }

            Console.Write("\nInforme o ID do contato a ser removido ou 'sair' para voltar ao menu: ");
            var entradaRemover = Console.ReadLine();

            if (entradaRemover?.ToLower() == "sair") {
                Console.WriteLine("\nRemoção cancelada.");
                Pausar();
                return;
            }

            if (int.TryParse(entradaRemover, out int idRemover)) {
                var contatoRemover = agenda.ObterContatoPorId(idRemover);
                if (contatoRemover != null) {

                    agenda.RemoverContato(idRemover);
                    Console.WriteLine("\nContato removido com sucesso!");

                } else {

                    Console.WriteLine("\nContato não encontrado!");
                }

            } else {

                Console.WriteLine("\nID inválido!");
            }

            Pausar();
        }
    }
}
