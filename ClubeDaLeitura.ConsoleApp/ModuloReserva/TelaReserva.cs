using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva;

internal class TelaReserva : TelaBase
{
    public override void Registrar()
    {
        ApresentarCabecalho();

        Console.WriteLine($"Cadastrando {tipoEntidade}...");

        Console.WriteLine();

        var entidade = (Reserva)ObterRegistro();

        var erros = entidade.Validar();

        if (erros.Count > 0)
        {
            ApresentarErros(erros);
            return;
        }

        var conseguiuReservar = entidade.StatusReserva();

        if (!conseguiuReservar)
        {
            ExibirMensagem("A reserva não foi possível", ConsoleColor.DarkYellow);
            return;
        }

        repositorio.Cadastrar(entidade);

        ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
    }

    public override void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            ApresentarCabecalho();

            Console.WriteLine("Visualizando Reservas...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -10}",
            "Id", "Revista", "Status"
        );

        var ReservasCadastrados = repositorio.SelecionarTodos();

        foreach (Reserva reserva in ReservasCadastrados)
        {
            if (reserva == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -10}",
                reserva.Id,
                reserva.Revista.Titulo,
                reserva.Validade ? "Válida" : "Expirada"
            );
        }

        Console.ReadLine();
        Console.WriteLine();
    }

    protected override EntidadeBase ObterRegistro()
    {
        Console.WriteLine("A validade é de 2 dias");

        Console.Write("Digite a revista: ");
        var tituloRevista = Console.ReadLine();

        Console.Write("Digite o amigo: ");
        var nomeAmigo = Console.ReadLine();

        // Aqui você precisa obter uma instância de Amigo e Revista. 
        // Como exemplo, estou criando novas instâncias com valores padrão.
        // Você deve substituir isso pela lógica correta para obter um Amigo e uma Revista.
        var amigo = new Amigo(nomeAmigo, "Nome do responsável", "Telefone", "Endereço");
        var caixa = new Caixa("Etiqueta", "Cor", 7);
        var revista = new Revista(tituloRevista, "NumeroEdicao", 2022, caixa);

        var reserva = new Reserva(revista, amigo);

        return reserva;
    }
}