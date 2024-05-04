using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisição
{
    public class RepositorioRequisicao
    {
        public List<Requisicao> registroRequisicao = new List<Requisicao>();
        public Requisicao requisicao;
        public Paciente paciente;
        public Medicamento medicamento;
        public DominioRequisicao dRequisicao;
        public RepositorioRequisicao repositorioRequisicao;
        public void GuardarRequisicao(RepositorioPessoas rPessoas, RepositorioRequisicao rRequisicao, Requisicao requisicao)
        {
            registroRequisicao.Add(requisicao);
            dRequisicao.VerificarRequisicao(rPessoas, rRequisicao);
        }
        public void VerRequisição(RepositorioRequisicao rRequisicao, Medicamento medicamento, Paciente paciente)
        {
            foreach (Requisicao registro in rRequisicao.registroRequisicao)
            {
                Console.Write($"{registro.IdRequisicao} " +
                                            $"| {paciente.Nome}" +
                                            $"| {paciente.RegistroSUS}" +
                                            $"| {medicamento.Nome}");
            }
            Console.ReadKey();
        }
    }
}
