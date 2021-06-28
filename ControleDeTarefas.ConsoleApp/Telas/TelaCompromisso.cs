using ControleDeTarefas.ConsoleApp.Controlador;
using ControleDeTarefas.ConsoleApp.Domino;
using System;
using System.Collections.Generic;

namespace ControleDeTarefas.ConsoleApp.Telas
{
    public class TelaCompromisso : TelaBase
    {
        private readonly ControladorCompromisso controladorCompromisso;
        private readonly TelaContato telaContato;

        public TelaCompromisso(ControladorCompromisso controlador, TelaContato contato)
        {
            controladorCompromisso = controlador;
            telaContato = contato;
        }
        public void InserirCompromisso()
        {
            controladorCompromisso.InserindoCompromisso(ObterCompromisso());

            Console.WriteLine("inserido com sucesso!");
            Console.ReadLine();
        }
        public void ListarCompromissos()
        {
            string configuracaoColunasTabela = "{0,-5}|{1,-30}|{2,-25}|{3,-25}|{4,-10}|{5,-10}|{6,-10}";

            MontarCabecalho(configuracaoColunasTabela, "id", "assunto", "local", "data", "Hora Inicio", "Hora Termino", "Nome Do Contato");

            List<Compromisso> compromissos = controladorCompromisso.ListarCompromissos();
            foreach (Compromisso compromisso in compromissos)
            {
                Console.WriteLine(configuracaoColunasTabela, compromisso.Id, compromisso.Assunto, compromisso.Local, compromisso.Data_Compromisso, compromisso.Hora_Inicio, compromisso.Hora_Termino, compromisso.Nome_Contato);
            }
            Console.ReadLine();
        }
        public void Listar()
        {
            string opcao;

            Console.WriteLine("Escolha uma Opção");
            Console.WriteLine("1 - Todos os Compromissos");
            Console.WriteLine("2 - Compromissos Futuros");
            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                ListarCompromissos();
            }
            if (opcao == "2")
            {
                ListarCompromisso7Dias();
            }
        }
        public void ListarCompromisso7Dias()
        {
            string configuracaoColunasTabela = "{0,-5}|{1,-30}|{2,-25}|{3,-25}|{4,-10}|{5,-10}|{6,-10}";

            MontarCabecalho(configuracaoColunasTabela, "id", "assunto", "local", "data", "Hora Inicio", "Hora Termino", "Nome Do Contato");

            List<Compromisso> compromissos = controladorCompromisso.ListarCompromissos7dias();
            foreach (Compromisso compromisso in compromissos)
            {
                Console.WriteLine(configuracaoColunasTabela, compromisso.Id, compromisso.Assunto, compromisso.Local, compromisso.Data_Compromisso, compromisso.Hora_Inicio, compromisso.Hora_Termino, compromisso.Nome_Contato);
            }
            Console.ReadLine();
        }
        public void EditarCompromisso()
        {
            ListarCompromissos();


            Console.WriteLine("Informe o id do compromisso que pretende Editar");
            int id = Convert.ToInt32(Console.ReadLine());

            controladorCompromisso.EditarCompromisso(id, ObterCompromisso());

            Console.WriteLine("Editado com sucesso!");
            Console.ReadLine();
        }
        public void ExluirCompromisso()
        {
            ListarCompromissos();

            Console.WriteLine("Informe o id do Compromisso que deseja Excluir");
            int id = Convert.ToInt32(Console.ReadLine());

            controladorCompromisso.Excluir(id);

            Console.WriteLine("Exluido com sucesso");
            Console.ReadLine();

        }

        #region Metodos Privados
        private Compromisso ObterCompromisso()
        {
            telaContato.ListarContatos();

            Console.WriteLine("Informe o id do contato que pretende marcar uma compromisso");
            int id_Contato = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o assunto do compromisso: ");
            string assunto = Console.ReadLine();

            Console.WriteLine("Informe o local do compromisso, se for de forma remota Informe o Link: ");
            string local = Console.ReadLine();

            Console.WriteLine("Informe o data do Compromisso: ");
            DateTime data_Compromisso = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe a Hora de Inicio: ");
            string hora_Inicio = Console.ReadLine();

            Console.WriteLine("Informe a Hora de Termino: ");
            string hora_Termino = Console.ReadLine();

            return new Compromisso(assunto, local, data_Compromisso, hora_Inicio, hora_Termino, id_Contato);
        }
        #endregion

    }
}
