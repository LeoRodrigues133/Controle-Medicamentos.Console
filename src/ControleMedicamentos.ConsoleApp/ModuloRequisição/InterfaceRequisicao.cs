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
        public Paciente paciente;
        public RepositorioPessoas rPessoas;
        public Medicamento medicamento;
        public void GerarRequisicao(DominioRequisicao dRequisicao, RepositorioPessoas rPessoas, RepositorioMedicamentos repositorioMedicamentos, RepositorioRequisicao rRequisicao, DominioMedicamentos dMedicamentos)
        {
            Console.WriteLine("Receber requisição de medicamento");


            dRequisicao.VerMedicamentos(repositorioMedicamentos, dMedicamentos);
            string nomeMedicamento = Program.ObterValor<string>("Qual o nome do medicamento requisitado?\n");
            while (!dRequisicao.BuscarMedicamento(nomeMedicamento, repositorioMedicamentos))
            {
                nomeMedicamento = Program.ObterValor<string>("Qual o nome do medicamento requisitado?\n");

                int quantidadeSolicitada = Program.ObterValor<int>("Quantidade solicitada:\n\n");
                while (!dMedicamentos.RetirarMedicamento(quantidadeSolicitada, nomeMedicamento, medicamento, repositorioMedicamentos))
                    quantidadeSolicitada = Program.ObterValor<int>("Quantidade solicitada:\n\n");

                dRequisicao.VerPacientes(rPessoas);
                int registroSUS = Program.ObterValor<int>("Numero de registro no SUS:\n\n");
                while (!dRequisicao.VerificarNRSUS(registroSUS, paciente, rPessoas))
                    registroSUS = Program.ObterValor<int>("Numero de registro no SUS:\n\n");

                Requisicao novaRequisicao = new Requisicao(paciente.Nome, paciente.RegistroSUS, nomeMedicamento, quantidadeSolicitada);
                rRequisicao.GuardarRequisicao(rPessoas, rRequisicao, novaRequisicao);
            }
        }
    }
}
