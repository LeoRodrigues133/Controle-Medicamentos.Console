using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;
using System.Globalization;

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
        public void GuardarRequisicao(RepositorioPessoas rPessoas, RepositorioRequisicao rRequisicao, RepositorioMedicamentos rMedicamentos, Requisicao requisicao)
        {
            registroRequisicao.Add(requisicao);
            VerRequisicao(rRequisicao, rPessoas, rMedicamentos, paciente, medicamento, dRequisicao);
        }
        public void VerRequisicao(RepositorioRequisicao rRequisicao, RepositorioPessoas rPessoas, RepositorioMedicamentos rMedicamentos, Paciente paciente, Medicamento medicamento, DominioRequisicao dRequisicao)
        {
            dRequisicao.Cabecalho();
            foreach (Requisicao registro in rRequisicao.registroRequisicao)
            {
                Console.WriteLine($" {registro.Id} ".PadRight(5) +
                                            $"| {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(registro.nome)}".PadRight(19) +
                                            $"| {registro.NRSUS}".PadRight(14) +
                                            $"| {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(registro.medicamento)}".PadRight(20) +
                                            $"| {registro.retirada}".PadRight(11) + "|");
                dRequisicao.Rodape();
            }
            Console.ReadKey();
        }
    }
}
