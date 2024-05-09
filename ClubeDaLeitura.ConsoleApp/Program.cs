using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var repositorioAmigo = new RepositorioAmigo();
        var telaAmigo = new TelaAmigo();
        telaAmigo.tipoEntidade = "Amigo";
        telaAmigo.repositorio = repositorioAmigo;

        var repositorioCaixa = new RepositorioCaixa();
        var telaCaixa = new TelaCaixa();
        telaCaixa.tipoEntidade = "Caixa";
        telaCaixa.repositorio = repositorioCaixa;

        var repositorioRevista = new RepositorioRevista();
        var telaRevista = new TelaRevista();
        telaRevista.repositorio = repositorioRevista;
        telaRevista.tipoEntidade = "Revista";

        var repositorioEmprestimo = new RepositorioEmprestimo();
        var telaEmprestimo = new TelaEmprestimo();
        telaEmprestimo.repositorio = repositorioEmprestimo;
        telaEmprestimo.tipoEntidade = "Emprestimo";

        var repositorioReserva = new RepositorioReserva();
        var telaReserva = new TelaReserva();
        telaReserva.repositorio = repositorioReserva;
        telaReserva.tipoEntidade = "Reserva";

        telaEmprestimo.telaAmigo = telaAmigo;
        telaEmprestimo.telaRevista = telaRevista;

        telaEmprestimo.repositorioAmigo = repositorioAmigo;
        telaEmprestimo.repositorioRevista = repositorioRevista;

        while (true)
        {
            var opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

            if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                break;

            TelaBase tela = null;

            if (opcaoPrincipalEscolhida == '1')
                tela = telaAmigo;

            else if (opcaoPrincipalEscolhida == '2')
                tela = telaCaixa;

            else if (opcaoPrincipalEscolhida == '3')
                tela = telaRevista;

            else if (opcaoPrincipalEscolhida == '4')
                tela = telaEmprestimo;

            else if (opcaoPrincipalEscolhida == '5')
                tela = telaReserva;

            var operacaoEscolhida = tela.ApresentarMenu();

            if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                continue;

            if (operacaoEscolhida == '1')
                tela.Registrar();

            else if (operacaoEscolhida == '2')
                tela.Editar();

            else if (operacaoEscolhida == '3')
                tela.Excluir();

            else if (operacaoEscolhida == '4')
                tela.VisualizarRegistros(true);
        }

        Console.ReadLine();
    }
}