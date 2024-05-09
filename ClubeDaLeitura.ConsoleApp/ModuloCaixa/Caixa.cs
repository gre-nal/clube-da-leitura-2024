using System.Collections;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class Caixa : EntidadeBase
{
    public Caixa(string etiqueta, string cor, int diasEmprestimo)
    {
        Etiqueta = etiqueta;
        Cor = cor;
        DiasEmprestimo = diasEmprestimo;
    }

    public string Etiqueta { get; set; }
    public string Cor { get; set; }
    public int DiasEmprestimo { get; set; }
    public double Numero { get; set; }

    public override ArrayList Validar()
    {
        var erros = new ArrayList();

        if (string.IsNullOrEmpty(Etiqueta.Trim()))
            erros.Add("O campo \"etiqueta\" é obrigatório");

        if (string.IsNullOrEmpty(Cor.Trim()))
            erros.Add("O campo \"cor\" é obrigatório");

        if (DiasEmprestimo <= 0)
            erros.Add("O campo \"dias de empréstimo\" deve ser maior que zero");

        return erros;
    }
}