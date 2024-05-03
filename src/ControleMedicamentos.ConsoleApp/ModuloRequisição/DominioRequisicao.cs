using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;
using System.Globalization;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisição
{
    public class DominioRequisicao
    {
        public RepositorioRequisicao rRequisicao;
        public RepositorioPessoas rPessoas;
        public RepositorioMedicamentos rMedicamentos;

        public bool VerificarNRSUS(int NRSUS, RepositorioPessoas rPessoas, DominioRequisicao dominio)
        {

            Paciente verificador = rPessoas.RegistroPessoas.FirstOrDefault(p => p.RegistroSUS == NRSUS);

            if (verificador == null)
                return true;

            Console.WriteLine("Esta carteira do SUS já esta cadastrada!");
            Console.ReadKey();
            return false;
        }
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
            Paciente requisitante = rPessoas.RegistroPessoas.FirstOrDefault(p => p.Nome == nomePaciente);
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

            Verificador = rPessoas.RegistroPessoas.FirstOrDefault(RegistroSUS => RegistroSUS.RegistroSUS == verificarNRSUS);

            if (Verificador == null)
            {
                Console.WriteLine("Paciente não encontrado!");
                return false;
            }

            Console.WriteLine("NRSUS encontrado!");

            return true;
        }
        public void VerPacientes(RepositorioPessoas rPaciente)
        {
            foreach (Paciente paciente in rPaciente.RegistroPessoas)
            {
                Console.WriteLine($"| {paciente.Id}".PadRight(5) +
                                           $"| {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(paciente.Nome)}".PadRight(10) +
                                           $"| {paciente.Cpf}".PadRight(17) +
                                           $"| {paciente.RegistroSUS.ToString().PadRight(7)}" +
                                            " |");
            }
        }
        public void VerMedicamentos(RepositorioMedicamentos rMedicamentos, DominioMedicamentos dominio)
        {
            foreach (Medicamento medicamento in rMedicamentos.estoque)
            {
                {
                    Console.Write($"| {medicamento.Id}".PadRight(5) +
                                          $"| {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(medicamento.Nome)}".PadRight(19) + "|");
                    dominio.VerificarQuantidadeEstoque(medicamento);
                    Console.WriteLine("|");
                }
            }
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

