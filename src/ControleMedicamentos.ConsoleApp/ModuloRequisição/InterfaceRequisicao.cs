using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisição
{
    public class InterfaceRequisicao
    {
        public RepositorioMedicamentos repositorioMedicamentos;
        public DominioRequisicao dRequisicao;
        public Paciente Paciente;
        public RepositorioPessoas rPessoas;

        public void GerarRequisicao(DominioRequisicao dRequisicao, Paciente paciente, RepositorioPessoas rPessoas, RepositorioMedicamentos repositorioMedicamentos)
        {
            Console.WriteLine("Receber requisição de medicamento");

            string nomePaciente = Program.ObterValor<string>("Qual o nome do paciente?\n");
            if (dRequisicao.BuscarPaciente(nomePaciente, rPessoas))
            {
                Console.WriteLine("Paciente Encontrado!");
            }
            string nomeMedicamento = Program.ObterValor<string>("Qual o nome do medicamento requisitado?\n");
            if (dRequisicao.BuscarMedicamento(nomeMedicamento, repositorioMedicamentos))
            {
                Console.WriteLine("Medicamentos encontrado!");
            }
            int registroSUS = Program.ObterValor<int>("Numero de registro no SUS:\n\n");
            if (dRequisicao.VerificarNRSUS(registroSUS, paciente, rPessoas))
            {
                Requisicao requisicao = new Requisicao(registroSUS);
            }
        }
    }
}
