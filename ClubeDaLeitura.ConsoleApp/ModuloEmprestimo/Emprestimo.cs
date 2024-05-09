using System.Collections;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

internal class Emprestimo : EntidadeBase
{
    public Emprestimo(Revista revistaSelecionada, Amigo amigoSelecionado)
    {
        Revista = revistaSelecionada;
        Amigo = amigoSelecionado;

        DataEmprestimo = DateTime.Now;
        DataDevolucao = DataEmprestimo.AddDays(Revista.Caixa.Numero);
        EstaAberto = true;
    }

    public Revista Revista { get; set; }
    public Amigo Amigo { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucao { get; set; }
    public bool EstaAberto { get; set; }
    public double Multa { get; set; }

    public override ArrayList Validar()
    {
        var erros = new ArrayList();

        if (Revista == null)
            erros.Add("A revista precisa ser preenchida");

        if (Amigo == null)
            erros.Add("O amigo precisa ser informado");

        if (Amigo.TemMulta)
            erros.Add("O amigo possui multas em aberto");

        return erros;
    }

    public bool EmprestarRevista()
    {
        if (Amigo.JaTemEmprestimo)
            return false;

        Amigo.JaTemEmprestimo = true;
        return true;
    }

    public void VerificarEmprestimo()
    {
        if (EstaAberto && DateTime.Now > DataDevolucao)
        {
            Multa = CalcularMulta();
            Amigo.ReceberMulta(Multa);
        }
    }

    private double CalcularMulta()
    {
        var diasAtraso = (DateTime.Now - DataDevolucao).Days;
        return diasAtraso * 1.0;
    }
}