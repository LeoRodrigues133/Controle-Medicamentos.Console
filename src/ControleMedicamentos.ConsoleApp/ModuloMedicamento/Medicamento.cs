namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento
{
    public class Medicamento
    {
        public string nome, descricao;
        public int quantidade = 1000;
        public DateTime validade;

        public Medicamento(string nome, string descricao, int quantidade, DateTime validade)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.validade = validade;
        }

        public int VerificarQuantidade(int incrementarQuantidade)
        {
            incrementarQuantidade += quantidade;

            return incrementarQuantidade;
        }

        public static bool VerificarValidade(DateTime validade)
        {
            DateTime hoje = DateTime.Now;

            if (validade < hoje)
            {
                Console.WriteLine("Você está cadastrando um medicamento vencido!");
                return false;
            }
            else
            {
                Console.WriteLine("Na validade");
                return true;
            }
        }


    }
}
