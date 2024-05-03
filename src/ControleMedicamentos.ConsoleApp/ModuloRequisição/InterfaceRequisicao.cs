using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisição
{
    public class InterfaceRequisicao
    {
        public RepositorioMedicamentos repositorioMedicamentos;
        public DominioRequisicao dRequisicao;
        public Paciente Paciente;
        public RepositorioPessoas rPessoas;

        public void GerarRequisicao(DominioRequisicao dRequisicao, Paciente paciente, RepositorioPessoas rPessoas, RepositorioMedicamentos repositorioMedicamentos, DominioMedicamentos dMedicamentos, Medicamento medicamento)
        {
            Console.WriteLine("Receber requisição de medicamento");

            VerificarRetirada(dRequisicao, repositorioMedicamentos, dMedicamentos, medicamento);

            dRequisicao.VerPacientes(rPessoas);
            int registroSUS = Program.ObterValor<int>("Numero de registro no SUS:\n\n");

            if (dRequisicao.VerificarNRSUS(registroSUS, paciente, rPessoas))
            {
                Requisicao requisicao = new Requisicao(registroSUS);
            }
        }

        private static void VerificarRetirada(DominioRequisicao dRequisicao, RepositorioMedicamentos repositorioMedicamentos, DominioMedicamentos dMedicamentos, Medicamento medicamento)
        {
            dRequisicao.VerMedicamentos(repositorioMedicamentos, dMedicamentos);
            string nomeMedicamento = Program.ObterValor<string>("Qual o nome do medicamento requisitado?\n");
            while (!dRequisicao.BuscarMedicamento(nomeMedicamento, repositorioMedicamentos))
                nomeMedicamento = Program.ObterValor<string>("Qual o nome do medicamento requisitado?\n");

            int quantidadeSolicitada = Program.ObterValor<int>("Quantidade solicitada:\n\n");
            while (!dMedicamentos.RetirarMedicamento(quantidadeSolicitada, nomeMedicamento, medicamento, repositorioMedicamentos))
            {
                quantidadeSolicitada = Program.ObterValor<int>("Quantidade solicitada:\n\n");
            }
        }
    }
}
