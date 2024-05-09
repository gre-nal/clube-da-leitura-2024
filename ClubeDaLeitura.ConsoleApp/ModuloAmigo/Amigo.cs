using System.Collections;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class Amigo : EntidadeBase
{
    public Amigo(string nome, string nomeResponsavel, string telefone, string endereco)
    {
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        Telefone = telefone;
        Endereco = endereco;
        Multa = 0;
    }

    public string Nome { get; set; }
    public string NomeResponsavel { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public double Multa { get; set; }
    public bool TemMulta => Multa > 0;
    public bool JaTemEmprestimo { get; set; }
    public bool JatemReserva { get; set; }


    public override ArrayList Validar()
    {
        var erros = new ArrayList();

        if (Nome.Length < 3)
            erros.Add("O Nome do Amigo precisa conter ao menos 3 caracteres");

        if (NomeResponsavel.Length < 3)
            erros.Add("O Nome do Responsavel precisa conter ao menos 3 caracteres");

        if (string.IsNullOrEmpty(Telefone))
            erros.Add("O Telefone precisa ser preenchido");

        if (string.IsNullOrEmpty(Endereco))
            erros.Add("O Endereco precisa ser preenchido");
        if (JaTemEmprestimo)
            erros.Add("O Amigo já possui um emprestimo em aberto");
        if (JatemReserva)
            erros.Add("O Amigo já possui uma reserva em aberto");
        if (Multa < 0)
            erros.Add("Multa em aberto");

        return erros;
    }

    public void ReceberMulta(double valor)
    {
        Multa += valor;
    }
}