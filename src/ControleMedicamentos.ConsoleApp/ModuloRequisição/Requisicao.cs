using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloBase;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisição
{
    public class Requisicao : Entidade
    {
        public RepositorioMedicamentos rM;
        public RepositorioPessoas rP;
        public int IdRequisicao;

        public Requisicao(int IdRequisicao) : base ()
        {
        }
    }
}
