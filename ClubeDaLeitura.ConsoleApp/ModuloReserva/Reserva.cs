using System.Collections;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva;

public class Reserva : EntidadeBase
{
    public bool Validade;

    public Reserva(Amigo amigo, Revista revista)
    {
        Amigo = amigo;
        Revista = revista;
        DataExpiracao = DateTime.Now.AddDays(2);
        Validade = true;
    }

    public Revista Revista { get; set; }
    public Amigo Amigo { get; set; }
    public DateTime DataExpiracao { get; set; }

    public override ArrayList Validar()
    {
        var erros = new ArrayList();

        if (Validade == false)
            erros.Add("\"Validade\" foi expirada");

        if (Revista == null)
            erros.Add("O campo \"revista\" precisa ser preenchida");

        if (Amigo == null)
            erros.Add("O campo \"amigo\" precisa ser informado");

        return erros;

        throw new NotImplementedException();
    }

    public bool ReservarRevista()
    {
        if (Amigo.JatemReserva)
            return false;

        Amigo.JatemReserva = true;
        return true;
    }

    public bool StatusReserva()
    {
        if (DateTime.Now > DataExpiracao)
            _ = Validade;

        return Validade;
    }
}