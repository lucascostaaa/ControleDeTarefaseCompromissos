﻿using ControleDeTarefas.ConsoleApp.Telas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tarefas Requisitos[100%]
            // Inserir no Banco [OK]
            // Editar Banco [OK]
            // Excluir do Banco [OK]
            // VIsualizar do Banco [OK]
            #endregion

            #region Contatos Requisitos[100%]
            // Inserir no Banco [OK]
            // Editar Banco [OK]
            // Excluir do Banco [OK]
            // VIsualizar do Banco [OK]
            // Agrupar por Cargo [OK}
            #endregion

            #region Compromissos Requisitos[90%]
            // Inserir no Banco [OK]
            // Editar Banco [OK]
            // Excluir do Banco [OK]
            // VIsualizar do Banco [OK]
            // Visualizar proximos 7 dias[NAO SEI ESTA CORRETO]

            #endregion

            #region Testes[80%]
            // Faltou teste do Editar de Contato e de Tarefa
            // Faltou alguns testes de validação
            #endregion

            TelaMenu telamenu = new TelaMenu();
            telamenu.RetornaMenu();


        }
    }
}
