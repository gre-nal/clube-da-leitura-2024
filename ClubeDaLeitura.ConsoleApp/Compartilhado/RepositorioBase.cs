namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

internal abstract class RepositorioBase
{
    private int contadorId = 1;
    private readonly EntidadeBase[] registros = new EntidadeBase[100];

    public void Cadastrar(EntidadeBase novoRegistro)
    {
        novoRegistro.Id = contadorId++;

        RegistrarItem(novoRegistro);
    }

    public bool Editar(int id, EntidadeBase novaEntidade)
    {
        novaEntidade.Id = id;

        for (var i = 0; i < registros.Length; i++)
            if (registros[i] == null)
            {
            }

            else if (registros[i].Id == id)
            {
                registros[i] = novaEntidade;

                return true;
            }

        return false;
    }

    public bool Excluir(int id)
    {
        for (var i = 0; i < registros.Length; i++)
            if (registros[i] == null)
            {
            }

            else if (registros[i].Id == id)
            {
                registros[i] = null;
                return true;
            }

        return false;
    }


    public EntidadeBase[] SelecionarTodos()
    {
        return registros;
    }

    public EntidadeBase SelecionarPorId(int id)
    {
        for (var i = 0; i < registros.Length; i++)
        {
            var e = registros[i];

            if (e == null)
                continue;

            if (e.Id == id)
                return e;
        }

        return null;
    }

    public bool Existe(int id)
    {
        for (var i = 0; i < registros.Length; i++)
        {
            var e = registros[i];

            if (e == null)
                continue;

            if (e.Id == id)
                return true;
        }

        return false;
    }

    protected void RegistrarItem(EntidadeBase novoRegistro)
    {
        for (var i = 0; i < registros.Length; i++)
            if (registros[i] != null)
            {
            }

            else
            {
                registros[i] = novoRegistro;
                break;
            }
    }
}