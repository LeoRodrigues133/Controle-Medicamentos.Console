using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento
{
    public class Requisicao
    {
        public Paciente requisitante; //Nome do paciente
        public Medicamento medicamentoRequisitado; // Nome do medicamento, Data de validade do medicamento
        public static int GeradorDeRequisicao;
        public int numeroRequisicao = GeradorDeRequisicao;


        public Requisicao(int numeroRequisicao)
        {
            this.numeroRequisicao = GerarNumeroRequisicao();
        }

        public string GerarRequisicao()
        {
            string nomeMedicamento = Program.ObterValor<string>("Qual o nome do medicamento requisitado?\n");
            string nomePaciente = Program.ObterValor<string>("Qual o nome do paciente?\n");
            string registroSUS = Program.ObterValor<string>("Numero de registro no SUS:");

            string formulario = $"Número da requisição:{numeroRequisicao}\nNumero de Registro SUS:{registroSUS}\nNome: {nomePaciente}\nMedicamento:{nomeMedicamento}\n";

            return formulario;
        }

        public int GerarNumeroRequisicao()
        {
            numeroRequisicao = 0;

            return ++GeradorDeRequisicao;
        }

    }
}
