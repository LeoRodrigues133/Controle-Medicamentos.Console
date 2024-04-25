using ControleMedicamentos.ConsoleApp.ModuloBase;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento
{
    public class Medicamento : Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }

        public Medicamento(int id,string nome, string descricao, int quantidade, DateTime validade) 
        {
            Nome = nome;
            Descricao = descricao;
            Quantidade = quantidade;
            Validade = validade;
        }

        public int VerificarQuantidade(int incrementarQuantidade)
        {
            incrementarQuantidade += Quantidade;

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
                Console.WriteLine("Medicamento na validade");
                return true;
            }
        }
        public override string ToString()
        {
            return $"|{Nome.PadRight(19)}| {Descricao.PadRight(30)}| {Quantidade.ToString().PadRight(7)} | {Validade.ToShortDateString().PadRight(12)} |";
        }

    }
}
