using Controle_de_Medicamentos_2024_ConsoleApp;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisição
{
    public class InterfaceRequisito
    {
        public DominioRequisicao dRequisicao;

        public void GerarRequisicao()
        {
            Console.WriteLine("Receber requisição de medicamento");

            string nomePaciente = Program.ObterValor<string>("Qual o nome do paciente?\n");
            string nomeMedicamento = Program.ObterValor<string>("Qual o nome do medicamento requisitado?\n");
            int registroSUS = Program.ObterValor<int>("Numero de registro no SUS:\n\n");
            if (dRequisicao.VerificarNRSUS(registroSUS))
                if(dRequisicao.BuscarMedicamento(nomeMedicamento))
                    if (dRequisicao.BuscarPaciente(nomePaciente))
                    {
                        Requisicao requisicao = new Requisicao(registroSUS);
                    }
        }
    }
}
