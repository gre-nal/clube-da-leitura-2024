using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista : TelaBase
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
                "Id", "Título", "Número Edição", "Ano"
            );

            EntidadeBase[] RevistaCadastrados = repositorio.SelecionarTodos();

            foreach (Revista revista in RevistaCadastrados)
            {
                if (revista == null)
                    continue;

                Console.WriteLine(
                "{0, -10} | {1, -10} | {2, -15} | {3, -10}",
                    revista.Id, revista.Titulo, revista.NumeroEdicao, revista.Ano
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite a revista: ");
            string Titulo = Console.ReadLine();

            Console.Write("Digite a cor: ");
            string NumeroEdicao = Console.ReadLine();

            Console.Write("Digite a etiqueta");
            int Ano = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data de validade: ");
            DateTime dataValidade = Convert.ToDateTime(Console.ReadLine());

            Caixa caixa = new Caixa(Titulo, NumeroEdicao, Ano, dataValidade);

            return caixa;
        }
    }
}
