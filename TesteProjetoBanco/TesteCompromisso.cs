using ControleDeTarefas.ConsoleApp.Controlador;
using ControleDeTarefas.ConsoleApp.Domino;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TesteProjetoBanco
{
    [TestClass]
    public class TesteCompromisso
    {
        private ControladorCompromisso controlador;

        public TesteCompromisso()
        {
            controlador = new ControladorCompromisso();
        }

        [TestMethod]
        public void DeveInserirCompromisso()
        {
            DateTime data_Compromisso = DateTime.Now;
            Compromisso compromisso = new Compromisso("Teste Unitario", "testeUnitario@gmail.com", data_Compromisso, "18:50", "19:30", 12);
            controlador.InserindoCompromisso(compromisso);
            int id = compromisso.Id;
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void DeveExcluirCompromisso()
        {
            DateTime data_Compromisso = DateTime.Now;
            Compromisso compromisso = new Compromisso("Teste Unitario Excluir", "testeUnitario@gmail.com", data_Compromisso, "18:50", "19:30", 4);
            controlador.InserindoCompromisso(compromisso);
            int id = compromisso.Id;
            controlador.Excluir(id);
            Assert.IsFalse(controlador.ListarCompromissos().Contains(compromisso));
        }
        [TestMethod]
        public void DeveRetornarTodosOsCompromissos()
        {
            DateTime data_Compromisso = DateTime.Now;
            Compromisso compromisso = new Compromisso("Teste Unitario Visualizar", "testeUnitario@gmail.com", data_Compromisso, "18:50", "19:30", 6);

            controlador.InserindoCompromisso(compromisso);

            Assert.IsFalse(controlador.ListarCompromissos().Contains(compromisso));
        }
    }
}
