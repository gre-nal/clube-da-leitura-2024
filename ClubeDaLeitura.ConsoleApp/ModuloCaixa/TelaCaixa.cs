using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

internal class TelaCaixa : TelaBase
{
    public override void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            ApresentarCabecalho();

            Console.WriteLine("Visualizando Caixas...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -10} | {2, -15} | {3, -10}",
            "Id", "Etiqueta", "Cor", "Dias de Empréstimo"
        );

        var CaixasCadastradas = repositorio.SelecionarTodos();

        foreach (Caixa caixa in CaixasCadastradas)
        {
            if (caixa == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -10} | {2, -15} | {3, -10}",
                caixa.Id, caixa.Etiqueta, caixa.Cor, caixa.DiasEmprestimo
            );
        }

        Console.ReadLine();
        Console.WriteLine();
    }

    protected override EntidadeBase ObterRegistro()
    {
        Console.Write("Digite a etiqueta da caixa: ");
        var etiqueta = Console.ReadLine();

        Console.Write("Digite a cor da caixa: ");
        var cor = Console.ReadLine();

        Console.Write("Digite a quantidade de dias de empréstimo: ");
        var diasEmprestimo = Convert.ToInt32(Console.ReadLine());

        var caixa = new Caixa(etiqueta, cor, diasEmprestimo);

        return caixa;
    }
}