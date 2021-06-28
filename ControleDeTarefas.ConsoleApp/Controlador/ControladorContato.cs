using ControleDeTarefas.ConsoleApp.Conexao;
using ControleDeTarefas.ConsoleApp.Domino;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.ConsoleApp.Controlador
{
    public class ControladorContato : Conexao.Conexao
    {
        public void InserirContato(Contato contato)
        {
            SqlCommand comandoInserir = new SqlCommand();
            comandoInserir.Connection = CriarConexao();

            string sqlInsercao =

            @"INSERT INTO TB_CONTATOS
            (
	            [NOME],
	            [EMAIL],
	            [TELEFONE],
                [EMPRESA],
                [CARGO]
            )
            VALUES
            (
	            @NOME,
	            @EMAIL,
	            @TELEFONE,
                @EMPRESA,
                @CARGO
            )";

            sqlInsercao +=
                @"SELECT SCOPE_IDENTITY();";


            comandoInserir.CommandText = sqlInsercao;

            comandoInserir.Parameters.AddWithValue("NOME", contato.Nome);
            comandoInserir.Parameters.AddWithValue("EMAIL", contato.Email);
            comandoInserir.Parameters.AddWithValue("TELEFONE", contato.Telefone);
            comandoInserir.Parameters.AddWithValue("EMPRESA", contato.Empresa);
            comandoInserir.Parameters.AddWithValue("CARGO", contato.Cargo);

            object id = comandoInserir.ExecuteScalar();

            contato.Id = Convert.ToInt32(id);

            FecharConexao();
        }
        public List<Contato> ListarContatos()
        {
            SqlCommand comandoVizualisar = new SqlCommand();
            comandoVizualisar.Connection = CriarConexao();

            string sqlVisualizar =
             @"SELECT
                [ID],
                [NOME],
                [EMAIL],
                [TELEFONE],
                [EMPRESA],
                [CARGO] 
            FROM TB_Contatos
            ORDER BY 

                [CARGO];";

            comandoVizualisar.CommandText = sqlVisualizar;

            SqlDataReader lerconsultas = comandoVizualisar.ExecuteReader();

            List<Contato> contatos = new List<Contato>();

            while (lerconsultas.Read())
            {
                int id = Convert.ToInt32(lerconsultas["Id"]);
                string nome = Convert.ToString(lerconsultas["Nome"]);
                string email = Convert.ToString(lerconsultas["Email"]);
                string telefone = Convert.ToString(lerconsultas["Telefone"]);
                string empresa = Convert.ToString(lerconsultas["Empresa"]);
                string cargo = Convert.ToString(lerconsultas["Cargo"]);

                Contato contato = new Contato(id, nome, email, telefone, empresa, cargo);
                contatos.Add(contato);
            }

            FecharConexao();

            return contatos;
        }
        public void EditarContato(int id, Contato contato)

        {
            SqlCommand comandoEdicao = new SqlCommand();
            comandoEdicao.Connection = CriarConexao();

            string sqlAtualiza = @"UPDATE TB_Contatos

            SET
            [NOME] = @NOME, 
		    [EMAIL] = @EMAIL,
		    [TELEFONE] = @TELEFONE,
		    [EMPRESA] = @EMPRESA,
            [CARGO] = @CARGO

            WHERE
                [ID] = @ID";


            comandoEdicao.CommandText = sqlAtualiza;

            comandoEdicao.Parameters.AddWithValue("ID", id);
            comandoEdicao.Parameters.AddWithValue("NOME", contato.Nome);
            comandoEdicao.Parameters.AddWithValue("EMAIL", contato.Email);
            comandoEdicao.Parameters.AddWithValue("TELEFONE", contato.Telefone);
            comandoEdicao.Parameters.AddWithValue("EMPRESA", contato.Empresa);
            comandoEdicao.Parameters.AddWithValue("CARGO", contato.Cargo);

            comandoEdicao.ExecuteNonQuery();

            FecharConexao();

        }
        public void Excluir(int id)
        {
            SqlCommand comandoExcluir = new SqlCommand();
            comandoExcluir.Connection = CriarConexao();

            string sqlDelete = @"DELETE FROM TB_Contatos
             WHERE
             [ID] = @ID";

            comandoExcluir.CommandText = sqlDelete;

            comandoExcluir.Parameters.AddWithValue("ID", id);

            comandoExcluir.ExecuteNonQuery();

            FecharConexao();
        }
    }
}
