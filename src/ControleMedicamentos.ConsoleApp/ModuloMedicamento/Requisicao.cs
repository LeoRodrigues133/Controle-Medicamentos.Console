using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento
{
    public class Requisicao
    {
        public Paciente requisitante; //Nome do paciente
        public Medicamento medicamentoRequisitado; // Nome do medicamento, Data de validade do medicamento
        public static int geradorDeRequisicao;
        public int numeroRequisicao = geradorDeRequisicao;


        public Requisicao(int numeroRequisicao)
        {
            this.numeroRequisicao = GerarNumeroRequisicao();
        }

        public string GerarRequisicao()
        {
            string nomeMedicamento = "Dipirona";
            string nomePaciente = "Carlos";
            DateTime validadeMedicamento = new DateTime(12 / 12 / 2050);

            string formulario = $"Número da requisição:{numeroRequisicao}\nNome: {nomePaciente}\nMedicamento:{nomeMedicamento}\nValidade:{validadeMedicamento}";

            return formulario;
        }

        public int GerarNumeroRequisicao()
        {
            numeroRequisicao = 0;

            return ++geradorDeRequisicao;
        }

    }
}
