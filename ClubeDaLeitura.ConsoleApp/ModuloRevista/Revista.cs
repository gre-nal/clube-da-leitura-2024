using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class Revista : EntidadeBase
    {
        public Revista(string titulo, string numeroEdicao, int ano, Caixa caixa)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            Ano = ano;
            Caixa = caixa;
        }

        public string Titulo { get; set; }
        public string NumeroEdicao { get; set; }
        public int Ano { get; set; }
        public Caixa Caixa { get; set; }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Titulo.Trim()))
                erros.Add("O campo \"título\" é obrigatório");

            if (string.IsNullOrEmpty(NumeroEdicao.Trim()))
                erros.Add("O campo \"número de edição\" é obrigatório");

            DateTime momento = DateTime.Now;
            if (Ano > momento.Year)
                erros.Add("O campo \"ano\" não pode ser maior que o ano atual");

            if (Caixa == null)
                erros.Add("O campo \"caixa\" é obrigatório");

            return erros;
        }
    }
}