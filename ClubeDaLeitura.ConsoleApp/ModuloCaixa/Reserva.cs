using System.Collections;
using ClubeDaLeitura.ConsoleApp;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Reserva : EntidadeBase
    {
        private string? titulo;
        private string? numeroEdicao;
        private int ano;
        private DateTime dataValidade;

        public Reserva(string revista, string cor, string etiqueta, DateTime tempoEmprestimo)
        {
            Revista = revista;
            Cor = cor;
            Etiqueta = etiqueta;
            TempoEmprestimo = tempoEmprestimo;
        }

        public Reserva(string? titulo, string? numeroEdicao, int ano, DateTime dataValidade)
        {
            this.titulo = titulo;
            this.numeroEdicao = numeroEdicao;
            this.ano = ano;
            this.dataValidade = dataValidade;
        }

        public string Revista { get; set; }
        public string Cor { get; set; }
        public string Etiqueta { get; set; }
        private DateTime TempoEmprestimo { get; set; }
        public double Numero { get; set; }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Revista.Trim()))
                erros.Add("O campo \"revista\" é obrigatório");

            if (string.IsNullOrEmpty(Cor.Trim()))
                erros.Add("O campo \"cor\" é obrigatório");

            if (string.IsNullOrEmpty(Etiqueta.Trim()))
                erros.Add("O campo \"etiqueta\" é obrigatório");

            DateTime hoje = DateTime.Now.Date;

            if (TempoEmprestimo < hoje)
                erros.Add("O campo \"data de validade\" não pode ser menor que a data atual");

            return erros;
        }
    }
}