using ClubeDaLeitura.ConsoleApp.ModuloAmigo;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<T> where T : EntidadeBase
{
    protected List<T> registros = new List<T>();
    protected int contadorId = 1;

    public void Cadastrar(T novoRegistro)
    {
        novoRegistro.Id = contadorId++;

        registros.Add(novoRegistro);
    }

    public bool Editar(int id, EntidadeBase novaEntidade)
    {
        novaEntidade.Id = id;

        foreach (T entidade in registros)
        {
            if (entidade == null)
                continue;

            else if (entidade.Id == id)
            {
                entidade.AtualizarRegistro(novaEntidade);

                return true;
            }
        }

        return false;
    }

    public bool Excluir(int id)
    {
        foreach (T entidade in registros)
        {
            if (entidade == null)
                continue;

            else if (entidade.Id == id)
            {
                registros.Remove(entidade);

                return true;
            }
        }

        return false;
    }


    public List<T> SelecionarTodos()
    {
        return registros;
    }

    public T SelecionarPorId(int id)
    {
        foreach (T e in registros)
        {
            if (e == null)
                continue;

            else if (e.Id == id)
                return e;
        }

        return null;
    }

    public bool Existe(int id)
    {
        foreach (T e in registros)
        {
            if (e == null)
                continue;

            else if (e.Id == id)
                return true;
        }

        return false;
    }

    public static implicit operator RepositorioBase<T>(RepositorioAmigo v)
    {
        throw new NotImplementedException();
    }

    //protected void RegistrarItem(EntidadeBase novoRegistro)
    //{
    //    for (var i = 0; i < registros.Length; i++)
    //        if (registros[i] != null)
    //        {
    //        }

    //        else
    //        {
    //            registros[i] = novoRegistro;
    //            break;
    //        }
    //}
}