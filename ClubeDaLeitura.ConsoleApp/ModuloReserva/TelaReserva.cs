using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
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

                Console.WriteLine("Visualizando Empréstimos...");
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
                    reserva.Revista,
                    reserva.Validade
                );
            }

            Console.ReadLine();
            Console.WriteLine();
            throw new NotImplementedException();
        }

        protected override EntidadeBase ObterRegistro()
        {
            //Console.WriteLine($"A validade é de 2 dias");

            //Console.Write("Digite a revista: ");
            //string revista = Console.ReadLine();

            //Console.Write("Digite o amigo: ");
            //string amigo = Console.ReadLine();

            //Reserva reserva = new Reserva(revista, amigo);
            
            //return reserva;

            throw new NotImplementedException();
        }
    }
}
