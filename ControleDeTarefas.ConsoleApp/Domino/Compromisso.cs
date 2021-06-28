using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.ConsoleApp.Domino
{
    public class Compromisso
    {
        public Compromisso()
        {

        }
        //INSERIR
        public Compromisso(string assunto, string local, DateTime data_Compromisso, string hota_Inicio, string hora_Termino, int id_Contato)
        {
            Assunto = assunto;
            Local = local;
            Data_Compromisso = data_Compromisso;
            Hora_Inicio = hota_Inicio;
            Hora_Termino = hora_Termino;
            Id_Contato = id_Contato;
        }
        //VISUALIZA
        public Compromisso(int id, string assunto, string local, DateTime data_Compromisso, string hota_Inicio, string hora_Termino, string nome_Contato)
        {
            Id = id;
            Assunto = assunto;
            Local = local;
            Data_Compromisso = data_Compromisso;
            Hora_Inicio = hota_Inicio;
            Hora_Termino = hora_Termino;
            Nome_Contato = nome_Contato;
        }
        //EDITAR
        public Compromisso(int id, string assunto, string local, DateTime data_Compromisso, string hota_Inicio, string hora_Termino, int id_Contato)
        {
            Id = Id;
            Assunto = assunto;
            Local = local;
            Data_Compromisso = data_Compromisso;
            Hora_Inicio = hota_Inicio;
            Hora_Termino = hora_Termino;
            Id_Contato = id_Contato;
        }
        public int Id { get; set; }
        public string Assunto { get; set; }
        public string Local { get; set; }
        public DateTime Data_Compromisso { get; set; }
        public string Hora_Inicio { get; set; }
        public string Hora_Termino { get; set; }
        public int Id_Contato { get; set; }
        public string Nome_Contato { get; set; }
    }
}
