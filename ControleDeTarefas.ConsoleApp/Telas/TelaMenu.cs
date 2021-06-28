using ControleDeTarefas.ConsoleApp.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.ConsoleApp.Telas
{
    public class TelaMenu
    {
        private readonly TelaTarefa telaTarefa;
        private readonly ControladorTarefa controladorTarefa;
        private readonly TelaContato telaContato;
        private readonly ControladorContato controladorContato;
        private readonly TelaCompromisso telaCompromisso;
        private readonly ControladorCompromisso controladorCompromisso;

        public TelaMenu()
        {
            controladorTarefa = new ControladorTarefa();
            telaTarefa = new TelaTarefa(controladorTarefa);

            controladorContato = new ControladorContato();
            telaContato = new TelaContato(controladorContato);

            controladorCompromisso = new ControladorCompromisso();
            telaCompromisso = new TelaCompromisso(controladorCompromisso, telaContato);
        }

        private string ObterMenuTarefa()
        {
            string opcao;

            Console.WriteLine("Escolha um Opção");
            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Vizualizar");
            Console.WriteLine("Digite 3 para Editar");
            Console.WriteLine("Digite 4 para Deletar");
            opcao = Console.ReadLine();
            Console.Clear();

            if (opcao == "1")
            {
                telaTarefa.InserirTarefa();
            }
            if (opcao == "2")
            {
                telaTarefa.Listar();
            }
            if (opcao == "3")
            {
                telaTarefa.EditarTarefa();
            }
            if (opcao == "4")
            {
                telaTarefa.ExluirTarefa();
            }
            return opcao;
        }
        private string ObterMenuContato()
        {
            string opcao;


            Console.WriteLine("Escolha um Opção");
            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Vizualizar");
            Console.WriteLine("Digite 3 para Editar");
            Console.WriteLine("Digite 4 para Deletar");
            opcao = Console.ReadLine();
            Console.Clear();

            if (opcao == "1")
            {
                telaContato.InserirContato();
            }
            if(opcao == "2")
            {
                telaContato.ListarContatos();
            }
            if (opcao == "3")
            {
                telaContato.EditarContato();
            }
            if (opcao == "4")
            {
                telaContato.ExluirContato();
            }

            return opcao;
        }

        private string ObterMenuCompromisso()
        {
            string opcao;

            Console.WriteLine("Escolha Uma Opção");
            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Vizualizar");
            Console.WriteLine("Digite 3 para Editar");
            Console.WriteLine("Digite 4 para Deletar");
            opcao = Console.ReadLine();
            Console.Clear();


            if (opcao == "1")
            {
                telaCompromisso.InserirCompromisso();
            }
            if (opcao == "2")
            {
                telaCompromisso.Listar();
            }
            if (opcao == "3")
            {
                telaCompromisso.EditarCompromisso();
            }
            if (opcao == "4")
            {
                telaCompromisso.ExluirCompromisso();
            }

            return opcao;
        }
        public void RetornaMenu() 
        {
            string opcao;

            Console.Clear();

            Console.WriteLine("Digite 1 para o Cadastro de Tarefa");
            Console.WriteLine("Digite 2 para o Cadastro de Contato");
            Console.WriteLine("Digite 3 para o Cadastro de Compromisso");

            opcao = Console.ReadLine();
            Console.Clear();

            if (opcao == "1")
            {
                opcao = ObterMenuTarefa();
            }

            else if (opcao == "2")
            {
                opcao = ObterMenuContato();
            }
            else if(opcao == "3")
            {
                opcao = ObterMenuCompromisso();
            }

            Console.ReadLine();
        }
    }
}
