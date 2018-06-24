using System;


namespace Agenda.Models
{
    public class Pessoa
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataDeAniversario { get; set; }
    }
}