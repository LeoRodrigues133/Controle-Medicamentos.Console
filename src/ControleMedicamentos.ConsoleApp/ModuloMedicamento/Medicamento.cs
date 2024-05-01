using ControleMedicamentos.ConsoleApp.ModuloBase;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento
{
    public class Medicamento : Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }

        public Medicamento(int id, string nome, string descricao, int quantidade, DateTime validade) : base()
        {

            Nome = nome;
            Descricao = descricao;
            Quantidade = quantidade;
            Validade = validade;
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
    }
}
