﻿using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class TelaBase<T> where T : EntidadeBase
{
    public string tipoEntidade = "";
    public RepositorioBase<T> repositorio = null;

    public virtual char ApresentarMenu()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
        Console.WriteLine($"2 - Editar {tipoEntidade}");
        Console.WriteLine($"3 - Excluir {tipoEntidade}");
        Console.WriteLine($"4 - Visualizar {tipoEntidade}s");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        var operacaoEscolhida = Convert.ToChar(Console.ReadLine());

        return operacaoEscolhida;
    }
    protected void InserirRegistro(T entidade)
    {
        ArrayList erros = entidade.Validar();

        if (erros.Count > 0)
        {
            ApresentarErros(erros);
            return;
        }

        repositorio.Cadastrar(entidade);

        ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
    }

    public virtual void Registrar()
    {
        ApresentarCabecalho();

        Console.WriteLine($"Cadastrando {tipoEntidade}...");

        Console.WriteLine();

        var entidade = ObterRegistro();

        var erros = entidade.Validar();

        if (erros.Count > 0)
        {
            ApresentarErros(erros);
            return;
        }

        repositorio.Cadastrar(entidade);

        ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
    }

    public void Editar()
    {
        ApresentarCabecalho();

        Console.WriteLine($"Editando {tipoEntidade}...");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write($"Digite o ID do {tipoEntidade} que deseja editar: ");
        var idEntidadeEscolhida = Convert.ToInt32(Console.ReadLine());

        if (!repositorio.Existe(idEntidadeEscolhida))
        {
            ExibirMensagem($"O {tipoEntidade} mencionado não existe!", ConsoleColor.DarkYellow);
            return;
        }

        Console.WriteLine();

        var entidade = ObterRegistro();

        var erros = entidade.Validar();

        if (erros.Count > 0)
        {
            ApresentarErros(erros);
            return;
        }

        var conseguiuEditar = repositorio.Editar(idEntidadeEscolhida, entidade);

        if (!conseguiuEditar)
        {
            ExibirMensagem($"Houve um erro durante a edição de {tipoEntidade}", ConsoleColor.Red);
            return;
        }

        ExibirMensagem($"O {tipoEntidade} foi editado com sucesso!", ConsoleColor.Green);
    }

    public void Excluir()
    {
        ApresentarCabecalho();

        if (tipoEntidade == "Funcionario")
            Console.WriteLine($"Promovendo {tipoEntidade} à cliente...");
        else
            Console.WriteLine($"Excluindo {tipoEntidade}...");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write($"Digite o ID do {tipoEntidade} que deseja excluir: ");
        var idRegistroEscolhido = Convert.ToInt32(Console.ReadLine());

        if (!repositorio.Existe(idRegistroEscolhido))
        {
            ExibirMensagem($"O {tipoEntidade} mencionado não existe!", ConsoleColor.DarkYellow);
            return;
        }

        var conseguiuExcluir = repositorio.Excluir(idRegistroEscolhido);

        if (!conseguiuExcluir)
        {
            ExibirMensagem($"Houve um erro durante a exclusão do {tipoEntidade}", ConsoleColor.Red);
            return;
        }

        if (tipoEntidade == "Funcionario")
            ExibirMensagem($"O {tipoEntidade}promovido à cliente com sucesso!", ConsoleColor.Green);
        else
            ExibirMensagem($"O {tipoEntidade} foi excluído com sucesso!", ConsoleColor.Green);
    }

    public abstract void VisualizarRegistros(bool exibirTitulo);

    protected void ApresentarErros(ArrayList erros)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        for (var i = 0; i < erros.Count; i++)
            Console.WriteLine(erros[i]);

        Console.ResetColor();
        Console.ReadLine();
    }

    protected void ApresentarCabecalho()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|       Clube da Leitura               |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();
    }

    public void ExibirMensagem(string mensagem, ConsoleColor cor)
    {
        Console.ForegroundColor = cor;

        Console.WriteLine();

        Console.WriteLine(mensagem);

        Console.ResetColor();

        Console.ReadLine();
    }

    protected abstract T ObterRegistro();
}