using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisição
{
    public class DominioRequisicao
    {
        public RepositorioRequisicao rRequisicao;
        public RepositorioPessoas rPessoas;
        public RepositorioMedicamentos rMedicamentos;
        public bool BuscarMedicamento(string nomeMedicamento, RepositorioMedicamentos rMedicamentos)
        {
            Medicamento medicamentoRequisitado = rMedicamentos.estoque.FirstOrDefault(m => m.Nome == nomeMedicamento);
            if (medicamentoRequisitado == null)
            {
                Console.WriteLine("Nenhum medicamento encontrado.");
                return false;
            }
            else
                return true;
        }

        public bool BuscarPaciente(string nomePaciente, RepositorioPessoas rPessoas)
        {
            Paciente requisitante = rPessoas.registroGeral.FirstOrDefault(p => p.Nome == nomePaciente);
            if (requisitante == null)
            {
                Console.WriteLine("Paciente não encontrado");
                return false;
            }
            else
                return true;
        }
        public void AdicionarRegistro(Requisicao requisicao)
        {
            rRequisicao.registroRequisicao.Add(requisicao);
        }


        public bool VerificarNRSUS(int verificarNRSUS, Paciente Verificador, RepositorioPessoas rPessoas)
        {

            Verificador = rPessoas.registroGeral.FirstOrDefault(RegistroSUS => RegistroSUS.RegistroSUS == verificarNRSUS);

            if (Verificador == null)
            {
                Console.WriteLine("Paciente não encontrado!");
                return false;
            }

            Console.WriteLine("NRSUS encontrado!");

            return true;
        }
        public void VerificarRequisicao(RepositorioPessoas rPessoas, RepositorioRequisicao rRequisicao)
        {
            Console.Clear();

            foreach (Requisicao registro in rRequisicao.registroRequisicao)
            {
                Console.WriteLine($"| {rRequisicao.requisicao.Id}".PadRight(5) +
                                             $"| {rPessoas.paciente.Nome}".PadRight(10) +
                                             $"| {rPessoas.paciente.Cpf}".PadRight(17) +
                                             $"| {rPessoas.paciente.Endereco}".PadRight(12) +
                                             $"| {rPessoas.paciente.RegistroSUS.ToString().PadRight(7)}" +
                                             $"| {rPessoas.paciente.DataDeNascimento.ToShortDateString()}".PadRight(10) +
                                             " |");
            }
            Console.ReadKey();
        }
    }
}

