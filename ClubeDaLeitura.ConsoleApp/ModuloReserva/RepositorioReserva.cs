using ClubeDaLeitura.ConsoleApp.Compartilhado;
using Microsoft.Win32;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva;

public class RepositorioReserva : RepositorioBase
{
    private IEnumerable<Reserva> registros;

    public ArrayList SelecionarReservasEmAberto()
    {
        ArrayList reservasEmAberto = new ArrayList();

        foreach (Reserva e in registros)
        {
            if (!e.Expirada)
                reservasEmAberto.Add(e);
        }

        return reservasEmAberto;
    }
}