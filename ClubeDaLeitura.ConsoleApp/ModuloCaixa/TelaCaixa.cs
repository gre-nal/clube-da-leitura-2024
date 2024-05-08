using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
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
                "{0, -10} | {1, -10} | {2, -15}",
                "Id", "Revistas", "Cor", "Etiqueta"
            );

            EntidadeBase[] CaixasCadastrados = repositorio.SelecionarTodos();

            foreach (Caixa caixa in CaixasCadastrados)
            {
                if (caixa == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -10} | {2, -15}",
                    caixa.Id, caixa.Revista, caixa.Cor, caixa.Etiqueta
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite a revista: ");
            string revista = Console.ReadLine();

            Console.Write("Digite a cor: ");
            string Cor = Console.ReadLine();

            Console.Write("Digite a etiqueta");
            string Etiqueta = Console.ReadLine();

            Console.Write("Digite a data de validade: ");
            DateTime dataValidade = Convert.ToDateTime(Console.ReadLine());

            Caixa caixa = new Caixa(revista, Cor, Etiqueta, dataValidade);

            return caixa;
        }
    }
}
