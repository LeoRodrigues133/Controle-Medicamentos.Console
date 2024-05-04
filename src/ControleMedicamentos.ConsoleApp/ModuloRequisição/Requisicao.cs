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
        public string nome { get; }
        public string medicamento { get; }
        public int NRSUS { get; }
        public int retirada { get; }

        public Requisicao(string nome, int NRSUS, string medicamento, int retirada) : base()
        {
            Id = idRequisicao++;
            this.nome = nome;
            this.NRSUS = NRSUS;
            this.medicamento = medicamento;
            this.retirada = retirada;

        }
    }
}
