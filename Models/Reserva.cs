namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(int qtdeHospedes)
        {
            List<Pessoa> hospedes = new List<Pessoa>();
            for (int i = 0; i < qtdeHospedes; i++)
            {
                Console.WriteLine("Por favor qual é seu Nome Completo?");
                Pessoa pessoa = new Pessoa(Console.ReadLine());
                hospedes.Add(pessoa);
            }

            Hospedes = hospedes;

        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            //Retorna a quantidade de hóspedes (propriedade Hospedes)
            int totalHospedes = Hospedes.Count();
            return totalHospedes;
        }
        public void ListarHospedes()
        {
            if (Hospedes.Any())
            {
                foreach (var p in Hospedes)
                {
                    Console.WriteLine(p.NomeCompleto);
                }

            }
            else
            {
                Console.WriteLine("Não há hospedes cadastrados.");
            }


        }

        public decimal CalcularValorDiaria()
        {
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                decimal desconto = valor * 0.10M;
                valor = valor - desconto;
                return valor;
            }

            return valor;
        }
    }
}