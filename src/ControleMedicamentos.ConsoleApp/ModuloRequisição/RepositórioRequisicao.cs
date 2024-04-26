using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisição
{
    public class RepositórioRequisicao
    {
        public List<Requisicao> registroDeReceitas = new List<Requisicao>();
        public Requisicao requisicao;
        public Paciente paciente;
        
        public void GerarRequisicao()
        {
            Console.WriteLine("Receber requisição de medicamento");

            string nomeMedicamento = Program.ObterValor<string>("Qual o nome do medicamento requisitado?\n");
            string nomePaciente = Program.ObterValor<string>("Qual o nome do paciente?\n");
            string registroSUS = Program.ObterValor<string>("Numero de registro no SUS:\n\n");

            Requisicao novaRequisicao = new Requisicao(requisicao.Id);
            AdicionarRegistro(novaRequisicao);
        }

        private void AdicionarRegistro(Requisicao requisicao)
        {
            registroDeReceitas.Add(requisicao);
        }

        public void VerificarRequisicao()
        {
            Console.Clear();

            foreach (Requisicao registro in registroDeReceitas)
            {
                Console.WriteLine($"| {requisicao.Id}".PadRight(5) +
                                  $"| {paciente.Nome}".PadRight(10) +
                                  $"| {paciente.Cpf}".PadRight(17) +
                                  $"| {paciente.Endereco}".PadRight(12) +
                                  $"| {Paciente.RegistroSUS.ToString().PadRight(7)}" +
                                  $"| {paciente.DataDeNascimento.ToShortDateString()}".PadRight(10) +
                                  " |");
            }
            Console.ReadKey();
        }
    }
}
