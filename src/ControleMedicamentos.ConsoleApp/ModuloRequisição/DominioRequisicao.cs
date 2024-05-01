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
        public bool BuscarMedicamento(string nomeMedicamento)
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

        public bool BuscarPaciente(string nomePaciente)
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

        public bool VerificarEstoque(string medicamentoSolicitado)
        {
            Medicamento Verificador = rMedicamentos.estoque.FirstOrDefault(M => M.Nome == medicamentoSolicitado);

            if (Verificador == null)
            {
                Console.WriteLine("Medicamento em falta!");
                return false;
            }

            Console.WriteLine("Medicamento em estoque!");
            return true;

        }
        public bool VerificarRegistro(string verificarRegistro)
        {

            Paciente Verificador = rPessoas.registroGeral.FirstOrDefault(P => P.Nome == verificarRegistro);

            if (Verificador == null)
            {
                Console.WriteLine("Paciente não encontrado!"); return false;
            }

            Console.WriteLine("Paciente encontrado!");
            return true;
        }

        public bool VerificarNRSUS(int verificarNRSUS)
        {

            Paciente Vericador = rPessoas.registroGeral.FirstOrDefault(RegistroSUS => RegistroSUS.RegistroSUS == verificarNRSUS);

            if (Vericador == null)
                return false;

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

