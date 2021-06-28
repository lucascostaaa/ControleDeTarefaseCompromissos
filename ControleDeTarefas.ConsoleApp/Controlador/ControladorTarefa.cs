using ControleDeTarefas.ConsoleApp.Conexao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ControleDeTarefas.ConsoleApp.Controlador
{
    public class ControladorTarefa : Conexao.Conexao
    {
        public void InserirTarefa(Tarefa tarefa)
        {
            SqlCommand comandoInserir = new SqlCommand();
            comandoInserir.Connection = CriarConexao();

            string sqlInsercao =

                    @"INSERT INTO TB_Tarefas 
	                (
		                [TITULO], 
		                [DATACRIACAO], 
		                [DATACONCLUSAO],
                        [PERCENTUAL],
                        [PRIORIDADE]
	                ) 
	                VALUES
	                (
                        @TITULO, 
		                @DATACRIACAO, 
		                @DATACONCLUSAO,
                        @PERCENTUAL,
                        @PRIORIDADE
	                );";

            sqlInsercao +=
                @"SELECT SCOPE_IDENTITY();";



            comandoInserir.CommandText = sqlInsercao;

            comandoInserir.Parameters.AddWithValue("TITULO", tarefa.Titulo);
            comandoInserir.Parameters.AddWithValue("DATACRIACAO", tarefa.Datacriacao);
            comandoInserir.Parameters.AddWithValue("DATACONCLUSAO", tarefa.DataConclusao);
            comandoInserir.Parameters.AddWithValue("PERCENTUAL", tarefa.Percentual);
            comandoInserir.Parameters.AddWithValue("PRIORIDADE", tarefa.Prioridade);

            object id = comandoInserir.ExecuteScalar();

            tarefa.Id = Convert.ToInt32(id);

            FecharConexao();
        }
        public List<Tarefa> ListarTarefasPendentes()
        {
            SqlCommand comandoVizualisar = new SqlCommand();
            comandoVizualisar.Connection = CriarConexao();

            string sqlVisualizar =
            @"SELECT
                [ID],
                [TITULO],
                [DATACRIACAO],
                [DATACONCLUSAO],
                [PERCENTUAL],
                [PRIORIDADE] 
            FROM TB_Tarefas 
            WHERE
                [PERCENTUAL] < 100";


            comandoVizualisar.CommandText = sqlVisualizar;

            SqlDataReader lerconsultas = comandoVizualisar.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();

            while (lerconsultas.Read())
            {
                int id = Convert.ToInt32(lerconsultas["Id"]);
                string titulo = Convert.ToString(lerconsultas["Titulo"]);
                DateTime dataCriacao = Convert.ToDateTime(lerconsultas["dataCriacao"]);
                DateTime dataConclusao = Convert.ToDateTime(lerconsultas["DataConclusao"]);
                int percentual = Convert.ToInt32(lerconsultas["Percentual"]);
                string prioridade = Convert.ToString(lerconsultas["Prioridade"]);

                Tarefa tarefa = new Tarefa(id, titulo, dataCriacao, dataConclusao, percentual, prioridade);
                tarefas.Add(tarefa);

            }

            FecharConexao();

            return tarefas;
        }
        public List<Tarefa> ListarTarefasConcluidas()
        {
            SqlCommand comandoVizulisar = new SqlCommand();
            comandoVizulisar.Connection = CriarConexao();

            string sqlVizualizar =
                @"SELECT
                 [ID],
                 [TITULO],
                 [DATACRIACAO],
                 [DATACONCLUSAO],
                 [PERCENTUAL],
                 [PRIORIDADE] 
            FROM TB_Tarefas 
            WHERE
                 [PERCENTUAL] = 100";

            comandoVizulisar.CommandText = sqlVizualizar;

            SqlDataReader lerconsultas = comandoVizulisar.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();

            while (lerconsultas.Read())
            {
                int id = Convert.ToInt32(lerconsultas["Id"]);
                string titulo = Convert.ToString(lerconsultas["Titulo"]);
                DateTime dataCriacao = Convert.ToDateTime(lerconsultas["dataCriacao"]);
                DateTime dataConclusao = Convert.ToDateTime(lerconsultas["DataConclusao"]);
                int percentual = Convert.ToInt32(lerconsultas["Percentual"]);
                string prioridade = Convert.ToString(lerconsultas["Prioridade"]);

                Tarefa tarefa = new Tarefa(id, titulo, dataCriacao, dataConclusao, percentual, prioridade);
                tarefas.Add(tarefa);

            }
            FecharConexao();

            return tarefas;
        }
        public List<Tarefa> ListarTodasTarefas()
        {
            SqlCommand comandoVizulisar = new SqlCommand();
            comandoVizulisar.Connection = CriarConexao();

            string sqlVizualizar =
                 @"SELECT
                 [ID],
                 [TITULO],
                 [DATACRIACAO],
                 [DATACONCLUSAO],
                 [PERCENTUAL],
                 [PRIORIDADE] 
            FROM TB_Tarefas";

            comandoVizulisar.CommandText = sqlVizualizar;

            SqlDataReader lerconsultas = comandoVizulisar.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();

            while (lerconsultas.Read())
            {
                int id = Convert.ToInt32(lerconsultas["Id"]);
                string titulo = Convert.ToString(lerconsultas["Titulo"]);
                DateTime dataCriacao = Convert.ToDateTime(lerconsultas["dataCriacao"]);
                DateTime dataConclusao = Convert.ToDateTime(lerconsultas["DataConclusao"]);
                int percentual = Convert.ToInt32(lerconsultas["Percentual"]);
                string prioridade = Convert.ToString(lerconsultas["Prioridade"]);

                Tarefa tarefa = new Tarefa(id, titulo, dataCriacao, dataConclusao, percentual, prioridade);
                tarefas.Add(tarefa);

            }
            FecharConexao();

            return tarefas;
        }
        public void EditarTarefa(int id, Tarefa tarefa)

        {
            SqlCommand comandoEdicao = new SqlCommand();
            comandoEdicao.Connection = CriarConexao();

            string sqlAtualiza = @"UPDATE TB_Tarefas

            SET
            [TITULO] = @TITULO, 
		    [DATACONCLUSAO] = @DATACONCLUSAO,
		    [PERCENTUAL] = @PERCENTUAL,
		    [PRIORIDADE] = @PRIORIDADE

            WHERE
                [ID] = @ID";

            comandoEdicao.CommandText = sqlAtualiza;

            comandoEdicao.Parameters.AddWithValue("ID",id);
            comandoEdicao.Parameters.AddWithValue("TITULO", tarefa.Titulo);
            comandoEdicao.Parameters.AddWithValue("DATACONCLUSAO", tarefa.DataConclusao);
            comandoEdicao.Parameters.AddWithValue("PERCENTUAL", tarefa.Percentual);
            comandoEdicao.Parameters.AddWithValue("PRIORIDADE", tarefa.Prioridade);

            comandoEdicao.ExecuteNonQuery();

            FecharConexao();

        }
        public void Excluir(int id)
        {
            SqlCommand comandoExcluir = new SqlCommand();
            comandoExcluir.Connection = CriarConexao();

            string sqlDelete = @"DELETE FROM TB_Tarefas
             WHERE
             [ID] = @ID";

            comandoExcluir.CommandText = sqlDelete;

            comandoExcluir.Parameters.AddWithValue("ID",id);

            comandoExcluir.ExecuteNonQuery();

            FecharConexao();
        }
    }
}
