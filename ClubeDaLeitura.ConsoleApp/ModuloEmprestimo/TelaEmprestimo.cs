using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo : TelaBase, ITelaCadastravel
{
    public TelaAmigo telaAmigo = null;
    public RepositorioAmigo repositorioAmigo = null;
    public TelaRevista telaRevista = null;
    public RepositorioRevista repositorioRevista = null;

    public override char ApresentarMenu()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Cadastro de Novo Empréstimo");
        Console.WriteLine("2 - Conclusão de Empréstimo");
        Console.WriteLine("3 - Visualizar Empréstimos");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

        return operacaoEscolhida;
    }
    public override void Registrar()
    {
        ApresentarCabecalho();

        Console.WriteLine($"Cadastrando {tipoEntidade}...");

        Console.WriteLine();

        var entidade = (Emprestimo)ObterRegistro();

        var erros = entidade.Validar();

        if (erros.Count > 0)
        {
            ApresentarErros(erros);
            return;
        }

        VerificarEmprestimos();

        var conseguiuEmprestar = entidade.EmprestarRevista();

        if (!conseguiuEmprestar)
        {
            ExibirMensagem("O amigo já tem um empréstimo em aberto.", ConsoleColor.DarkYellow);
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

            Console.WriteLine("Visualizando Empréstimos...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -20} | {5, -5}",
            "Id", "Revista", "Amigo", "Data de Empréstimo", "Data de Devolução", "Status"
        );

        var emprestimosCadastrados = repositorio.SelecionarTodos();

        foreach (Emprestimo emprestimo in emprestimosCadastrados)
        {
            if (emprestimo == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -20} | {5, -5}",
                emprestimo.Id,
                emprestimo.Revista.Titulo,
                emprestimo.Amigo.Nome,
                emprestimo.DataEmprestimo.ToShortDateString(),
                emprestimo.DataDevolucao.ToShortDateString(),
                emprestimo.EstaAberto ? "Aberto" : "Concluído"
            );
        }

        Console.ReadLine();
        Console.WriteLine();
    }

    protected override EntidadeBase ObterRegistro()
    {
        telaRevista.VisualizarRegistros(false);

        Console.Write("Digite o ID da revista emprestada: ");
        var idRevista = Convert.ToInt32(Console.ReadLine());

        var revistaSelecionada = (Revista)repositorioRevista.SelecionarPorId(idRevista);

        telaAmigo.VisualizarRegistros(false);

        Console.Write("Digite o ID do amigo requisitante: ");
        var idAmigo = Convert.ToInt32(Console.ReadLine());

        var amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(idAmigo);

        var novoEmprestimo = new Emprestimo(revistaSelecionada, amigoSelecionado);

        return novoEmprestimo;
    }

    public void VerificarEmprestimos()
    {
        var emprestimosCadastrados = repositorio.SelecionarTodos();

        foreach (Emprestimo emprestimo in emprestimosCadastrados)
        {
            if (emprestimo == null)
                continue;

            emprestimo.VerificarEmprestimo();
        }
    }
}