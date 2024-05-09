using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

internal class TelaAmigo : TelaBase
{
    public override void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            ApresentarCabecalho();

            Console.WriteLine("Visualizando Amigos...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
            "Id", "Nome", "Telefone", "Endereco"
        );

        var amigosCadastrados = repositorio.SelecionarTodos();

        foreach (Amigo amigo in amigosCadastrados)
        {
            if (amigo == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                amigo.Id, amigo.Nome, amigo.Telefone, amigo.Endereco
            );
        }

        Console.ReadLine();
        Console.WriteLine();
    }

    protected override EntidadeBase ObterRegistro()
    {
        Console.Write("Digite o nome do Amigo: ");
        var nome = Console.ReadLine();

        Console.Write("Digite o nome do Responsavel do Amigo: ");
        var nomeResponsavel = Console.ReadLine();

        Console.Write("Digite o Telefone do Amigo: ");
        var telefone = Console.ReadLine();

        Console.Write("Digite o Endereco do Amigo: ");
        var endereco = Console.ReadLine();

        var novoAmigo = new Amigo(nome, nomeResponsavel, telefone, endereco);

        return novoAmigo;
    }
}