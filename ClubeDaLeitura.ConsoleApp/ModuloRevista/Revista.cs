using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class Revista : EntidadeBase
    {
        public Revista(string titulo, string numeroEdicao, int ano, Reserva caixa)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            Ano = ano;
            Caixa = caixa;
        }

        public string Titulo { get; set; }
        public string NumeroEdicao { get; set; }
        public int Ano { get; set; }
        public Reserva Caixa { get; set; }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Titulo.Trim()))
                erros.Add("O campo \"título\" é obrigatório");

            if (string.IsNullOrEmpty(NumeroEdicao.Trim()))
                erros.Add("O campo \"´número de edição\" é obrigatório");

            DateTime momento = new DateTime();
            if (Ano > momento.Year)
                erros.Add("O campo \"ano\" não pode ser maior que o ano atual");

            if (Caixa == null)
                erros.Add("o campo \"caixa\" é obrigatório");
           
            return erros;
        }
    }
}