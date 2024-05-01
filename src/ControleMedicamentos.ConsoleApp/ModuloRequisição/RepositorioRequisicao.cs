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
        public DominioRequisicao dRequisicao;
        public void GuardarRequisicao(RepositorioPessoas rPessoas, RepositorioRequisicao rRequisicao)
        {
            registroRequisicao.Add(requisicao);
            dRequisicao.VerificarRequisicao(rPessoas, rRequisicao);
        }

    }
}
