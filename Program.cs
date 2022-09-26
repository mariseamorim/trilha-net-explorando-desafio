using System.Text;
using DesafioProjetoHospedagem.Models;


Console.OutputEncoding = Encoding.UTF8;

string opcao = string.Empty;
bool exibirMenu = true;
Reserva reserva = new Reserva();

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar Reserva:");
    Console.WriteLine("2 - Listar Hóspedes");
    Console.WriteLine("3 - Encerrar");

    switch (Console.ReadLine())
    {

        case "1":
            Console.WriteLine("Qual é o tipo da suíte?");
            string tipoSuite = Console.ReadLine();
            Console.WriteLine("Qual é a capacidade da suíte?");
            int capacidade = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual é o valor da diária?");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());
            Suite suite = new Suite(tipoSuite: tipoSuite, capacidade: capacidade, valorDiaria: valorDiaria);



            Console.WriteLine("Quantos hospedes?");
            int qtdeHospedes = int.Parse(Console.ReadLine());
            reserva.CadastrarSuite(suite);
            // Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (suite.Capacidade >= qtdeHospedes)
            {

                reserva.CadastrarHospedes(qtdeHospedes);

            }
            else
            {
                //Lança exception quantidade de hóspedes for maior que capacidade suite;
                throw new ArgumentException
                ("Desculpe a quantidade de hospedes é maior que a capacidade da suíte!");
            }

            Console.WriteLine("Informe quantos dia deseja reservar");
            int diasReserva = int.Parse(Console.ReadLine());
            reserva.DiasReservados = diasReserva;

            Console.WriteLine($"Reserva efetuada com sucesso!");
            Console.WriteLine($"Quantidade de Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

            break;

        case "2":
            reserva.ListarHospedes();
            Console.WriteLine($"Valor a pagar: {reserva.CalcularValorDiaria()}");

            break;

        case "3":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();

}

Console.WriteLine("O programa se encerrou");
