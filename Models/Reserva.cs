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

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                throw new Exception($"Não é possível cadastrar todos os hóspedes. Essa suite suporte apenas {Suite.Capacidade} hospedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            return Hospedes != null ? Hospedes.Count : 0;
        }
        

        public decimal CalcularValorDiaria(Suite suite)
        {
            Suite = suite;
            // TODO: Retorna o valor da diária
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            if (Suite != null && DiasReservados > 0)
            {
                decimal valor;
                decimal valorTotal = DiasReservados * Suite.ValorDiaria;
                if (DiasReservados >= 10)
                {
                    decimal desconto = valorTotal * 0.10m;
                    valor = valorTotal - desconto;
                }
                else{
                    valor = valorTotal;
                }
                return valor;
            }
            else
            {
                throw new Exception("Suite não definida ou dias reservados inválidos.");
            }
        }
    }
}