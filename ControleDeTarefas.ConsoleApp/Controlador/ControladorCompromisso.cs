using ControleDeTarefas.ConsoleApp.Conexao;
using ControleDeTarefas.ConsoleApp.Domino;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace ControleDeTarefas.ConsoleApp.Controlador
{
    public class ControladorCompromisso : Conexao.Conexao
    {

        public void InserindoCompromisso(Compromisso compromisso)
        {
            SqlCommand comandoInserir = new SqlCommand();
            comandoInserir.Connection = CriarConexao();

            string sqlInsercao = @"INSERT INTO TB_COMPROMISSO
            (
                [ASSUNTO],
	            [LOCAL],
	            [DATA_COMPROMISSO],
                [HORA_INICIO],
                [HORA_TERMINO],
                [ID_CONTATO]
            )
            VALUES
            (
                @ASSUNTO,
                @LOCAL,
                @DATA_COMPROMISSO,
                @HORA_INICIO,
                @HORA_TERMINO,
                @ID_CONTATO
            )";

            sqlInsercao +=
             @"SELECT SCOPE_IDENTITY();";

            comandoInserir.CommandText = sqlInsercao;
            comandoInserir.Parameters.AddWithValue("ASSUNTO", compromisso.Assunto);
            comandoInserir.Parameters.AddWithValue("LOCAL", compromisso.Local);
            comandoInserir.Parameters.AddWithValue("DATA_COMPROMISSO", compromisso.Data_Compromisso);
            comandoInserir.Parameters.AddWithValue("HORA_INICIO", compromisso.Hora_Inicio);
            comandoInserir.Parameters.AddWithValue("HORA_TERMINO", compromisso.Hora_Termino);
            comandoInserir.Parameters.AddWithValue("ID_CONTATO", compromisso.Id_Contato);

            object id = comandoInserir.ExecuteScalar();

            compromisso.Id = Convert.ToInt32(id);

            FecharConexao();
        }
        public List<Compromisso> ListarCompromissos()
        {
            SqlCommand comandoVizualisar = new SqlCommand();
            comandoVizualisar.Connection = CriarConexao();

            string sqlVisualizar =
             @"SELECT
            [TB_Compromisso].Id,
            [ASSUNTO],
            [LOCAL],
            [DATA_COMPROMISSO],
            [HORA_INICIO],
            [HORA_TERMINO],
            [TB_Contatos].NOME

            FROM

            TB_Compromisso INNER JOIN
            TB_Contatos ON[TB_Compromisso].Id_Contato = [TB_Contatos].id";


            comandoVizualisar.CommandText = sqlVisualizar;

            SqlDataReader lerconsultas = comandoVizualisar.ExecuteReader();

            List<Compromisso> compromissos = new List<Compromisso>();

            while (lerconsultas.Read())
            {
                int id = Convert.ToInt32(lerconsultas["Id"]);
                string assunto = Convert.ToString(lerconsultas["Assunto"]);
                string local = Convert.ToString(lerconsultas["Local"]);
                DateTime data_Compromisso = Convert.ToDateTime(lerconsultas["Data_Compromisso"]);
                string hora_Inicio = Convert.ToString(lerconsultas["Hora_Inicio"]);
                string hora_Termino = Convert.ToString(lerconsultas["Hora_Termino"]);
                string nome_Contato = Convert.ToString(lerconsultas["Nome"]);

                Compromisso compromisso = new Compromisso(id, assunto, local, data_Compromisso, hora_Inicio, hora_Termino, nome_Contato);
                compromissos.Add(compromisso);
            }

            FecharConexao();

            return compromissos;
        }
        public List<Compromisso> ListarCompromissos7dias()
        {
            SqlCommand comandoVizualisar = new SqlCommand();
            comandoVizualisar.Connection = CriarConexao();

            string sqlVisualizar =
             @"SELECT
            [TB_Compromisso].Id,
            [ASSUNTO],
            [LOCAL],
            [DATA_COMPROMISSO],
            [HORA_INICIO],
            [HORA_TERMINO],
            [TB_Contatos].NOME

            FROM

            TB_Compromisso INNER JOIN
            TB_Contatos ON[TB_Compromisso].Id_Contato = [TB_Contatos].id

            WHERE DATEDIFF(DAY,[DATA_COMPROMISSO] , GETDATE()) >=7

            ";

            comandoVizualisar.CommandText = sqlVisualizar;

            SqlDataReader lerconsultas = comandoVizualisar.ExecuteReader();

            List<Compromisso> compromissos = new List<Compromisso>();

            while (lerconsultas.Read())
            {
                int id = Convert.ToInt32(lerconsultas["Id"]);
                string assunto = Convert.ToString(lerconsultas["Assunto"]);
                string local = Convert.ToString(lerconsultas["Local"]);
                DateTime data_Compromisso = Convert.ToDateTime(lerconsultas["Data_Compromisso"]);
                string hora_Inicio = Convert.ToString(lerconsultas["Hora_Inicio"]);
                string hora_Termino = Convert.ToString(lerconsultas["Hora_Termino"]);
                string nome_Contato = Convert.ToString(lerconsultas["Nome"]);

                Compromisso compromisso = new Compromisso(id, assunto, local, data_Compromisso, hora_Inicio, hora_Termino, nome_Contato);
                compromissos.Add(compromisso);
            }

            FecharConexao();

            return compromissos;
        }
        public void EditarCompromisso(int id, Compromisso compromisso)
        {
            SqlCommand comandoEdicao = new SqlCommand();
            comandoEdicao.Connection = CriarConexao();

            string sqlEdicao =
            @"UPDATE TB_Compromisso

            SET
            [ASSUNTO] = @ASSUNTO,
	        [LOCAL] = @LOCAL,
	        [DATA_COMPROMISSO] = @DATA_COMPROMISSO,
            [HORA_INICIO] = @HORA_INICIO,
            [HORA_TERMINO] = @HORA_TERMINO,
            [ID_CONTATO] = @ID_CONTATO

            WHERE
                [ID] = @ID";

            comandoEdicao.CommandText = sqlEdicao;

            comandoEdicao.Parameters.AddWithValue("ID", id);
            comandoEdicao.Parameters.AddWithValue("ASSUNTO", compromisso.Assunto);
            comandoEdicao.Parameters.AddWithValue("LOCAL", compromisso.Local);
            comandoEdicao.Parameters.AddWithValue("DATA_COMPROMISSO", compromisso.Data_Compromisso);
            comandoEdicao.Parameters.AddWithValue("HORA_INICIO", compromisso.Hora_Inicio);
            comandoEdicao.Parameters.AddWithValue("HORA_TERMINO", compromisso.Hora_Termino);
            comandoEdicao.Parameters.AddWithValue("ID_CONTATO", compromisso.Id_Contato);

            comandoEdicao.ExecuteNonQuery();

            FecharConexao();
        }
        public void Excluir(int id)
        {
            SqlCommand comandoExcluir = new SqlCommand();
            comandoExcluir.Connection = CriarConexao();

            string sqlDelete = @"DELETE FROM TB_Compromisso
             WHERE
             [ID] = @ID";

            comandoExcluir.CommandText = sqlDelete;

            comandoExcluir.Parameters.AddWithValue("ID", id);

            comandoExcluir.ExecuteNonQuery();

            FecharConexao();
        }
    }
}
