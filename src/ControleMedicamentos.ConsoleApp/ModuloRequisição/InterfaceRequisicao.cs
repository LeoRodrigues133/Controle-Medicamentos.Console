using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloRequisição;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class InterfaceRequisicao
    {
        private RepositorioMedicamentos rMedicamentos;
        private RepositorioPessoas rPessoas;
        private RepositorioRequisicao rRequisicao;

        public InterfaceRequisicao(RepositorioMedicamentos repositorioMedicamentos, RepositorioPessoas repositorioPessoas, RepositorioRequisicao repositorioRequisicao)
        {
            rMedicamentos = repositorioMedicamentos;
            rPessoas = repositorioPessoas;
            rRequisicao = repositorioRequisicao;
        }

        public void ProcessarRequisicao(DominioRequisicao dRequisicao, DominioMedicamentos dMedicamentos, RepositorioRequisicao rRequisicao, RepositorioPessoas rPessoas)
        {
            Paciente paciente = SelecionarPaciente(dRequisicao, rPessoas);
            Medicamento medicamento = SelecionarMedicamento(dRequisicao, rMedicamentos, dMedicamentos);
            int quantidadeSolicitada = ObterQuantidadeSolicitada(medicamento);

            if (medicamento != null && quantidadeSolicitada > 0)
            {
                CriarRequisicao(paciente.Nome, paciente.RegistroSUS, medicamento.Nome, quantidadeSolicitada, rRequisicao, rPessoas, dRequisicao);
                Console.WriteLine("Requisição processada com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao processar a requisição.");
            }
        }

        private Paciente SelecionarPaciente(DominioRequisicao dRequisicao, RepositorioPessoas rPessoas)
        {
            dRequisicao.VerPacientes(rPessoas);
            int registroSUS = Program.ObterValor<int>("Digite o número do registro SUS do paciente:\n");

            return rPessoas.RegistroPessoas.FirstOrDefault(p => p.RegistroSUS == registroSUS);
        }

        private Medicamento SelecionarMedicamento(DominioRequisicao dRequisicao, RepositorioMedicamentos rMedicamentos, DominioMedicamentos dMedicamentos)
        {
            dRequisicao.VerMedicamentos(rMedicamentos, dMedicamentos);
            string nomeMedicamento = Program.ObterValor<string>("Digite o nome do medicamento:\n");

            return rMedicamentos.estoque.FirstOrDefault(m => m.Nome == nomeMedicamento);
        }

        private int ObterQuantidadeSolicitada(Medicamento medicamento)
        {
            int quantidade = Program.ObterValor<int>("Digite a quantidade solicitada:\n");

            if (quantidade > medicamento.Quantidade)
            {
                Console.WriteLine("Quantidade solicitada não disponível no estoque.");
                return 0;
            }

            medicamento.Quantidade -= quantidade;
            return quantidade;
        }

        private void CriarRequisicao(string nome, int registroSUS, string medicamento, int quantidade, RepositorioRequisicao rRequisicao, RepositorioPessoas rPessoas, DominioRequisicao dRequisicao)
        {
            Requisicao novaRequisicao = new Requisicao(nome, registroSUS, medicamento, quantidade);
            rRequisicao.GuardarRequisicao(rPessoas, rRequisicao,rMedicamentos, novaRequisicao);
        }
    }
}
