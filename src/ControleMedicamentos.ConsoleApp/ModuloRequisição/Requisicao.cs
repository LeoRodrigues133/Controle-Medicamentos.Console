using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloBase;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisição
{
    public class Requisicao : Entidade
    {
        public int IdRequisicao;
        public static int idRequisicao = 1;
        public Requisicao(string nome, int NRSUS, string medicamento, int retirada) : base()
        {
            retirada = retirada;
            nome = nome;
            medicamento = medicamento;
            NRSUS = NRSUS;
            Id = idRequisicao++;

        }
    }
}
