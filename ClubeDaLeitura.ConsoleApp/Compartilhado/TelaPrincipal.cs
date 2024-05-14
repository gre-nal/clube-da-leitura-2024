using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private RepositorioAmigo repositorioAmigo;
    private TelaAmigo telaAmigo;

    public TelaPrincipal()
    {
        repositorioAmigo = new RepositorioAmigo();

        telaAmigo = new TelaAmigo();
        telaAmigo.tipoEntidade = "Amigo";
        telaAmigo.repositorio = repositorioAmigo;

        telaAmigo.CadastrarEntidadeTeste();
    }
    public static char ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|       Clube da Leitura               |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Cadastro de Amigos");
        Console.WriteLine("2 - Cadastro de Caixas");
        Console.WriteLine("3 - Cadastro de Revistas");
        Console.WriteLine("4 - Cadastro de Emprestimos");
        Console.WriteLine("5 - Cadastro de Reservas");

        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");

        var opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;
    }
}