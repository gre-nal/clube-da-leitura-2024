using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Revistas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -10} | {2, -15} | {3, -10} | {4, -10}",
                "Id", "Título", "Número Edição", "Ano", "Caixa"
            );

            EntidadeBase[] RevistasCadastradas = repositorio.SelecionarTodos();

            foreach (Revista revista in RevistasCadastradas)
            {
                if (revista == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -10} | {2, -15} | {3, -10} | {4, -10}",
                    revista.Id, revista.Titulo, revista.NumeroEdicao, revista.Ano, revista.Caixa.Etiqueta
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o título da revista: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o número da edição: ");
            string numeroEdicao = Console.ReadLine();

            Console.Write("Digite o ano da revista: ");
            int ano = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = new Caixa("Etiqueta", "Cor", 7);

            Revista revista = new Revista(titulo, numeroEdicao, ano, caixa);

            return revista;
        }
    }
}