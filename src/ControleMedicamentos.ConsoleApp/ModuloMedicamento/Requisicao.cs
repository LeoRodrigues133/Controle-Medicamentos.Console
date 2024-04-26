using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloBase;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento
{
    public class Requisicao : Entidade
    {
        public RepositorioMedicamentos rM;
        public RepositorioPessoas rP;
        public Paciente requisitante; //Nome do paciente
        public Medicamento medicamentoRequisitado; // Nome do medicamento, Data de validade do medicamento
        public int numeroRequisicao;


        public Requisicao(int numeroRequisicao)
        {
            this.numeroRequisicao = Id;
        }

        public string GerarRequisicao()
        {
            string nomeMedicamento = ""; string nomePaciente = "";
            int registroSUS = 0;
            VerificarRegistro(nomePaciente);
            VerificarEstoque(nomeMedicamento);
            VerificarNRSUS(registroSUS);

            string formulario = $"Número da requisição:{numeroRequisicao}\nNumero de Registro SUS:{registroSUS}\nNome: {nomePaciente}\nMedicamento:{nomeMedicamento}\n";

            return formulario;
        }
        public bool VerificarEstoque(string medicamentoSolicitado)
        {
            medicamentoSolicitado = Program.ObterValor<string>("Digite o nome do medicamento: \n");

            Medicamento Verificador = (Medicamento)rM.estoque.FirstOrDefault(M => M.Nome == medicamentoSolicitado);

            if (Verificador == null)
            {
                Console.WriteLine("Medicamento em falta!"); return false;
            }

            Console.WriteLine("Medicamento em estoque!");
            return true;

        }
        public bool VerificarRegistro(string verificarRegistro)
        {
            verificarRegistro = Program.ObterValor<string>("Digite o nome do paciente: \n");

            Paciente Verificador = rM.FirstOrDefault(P => P.Nome == verificarRegistro);

            if (Verificador == null)
            {
                Console.WriteLine("Paciente não encontrado!"); return false;
            }

            Console.WriteLine("Paciente encontrado!");
            return true;
        }

        public bool VerificarNRSUS(int verificarNRSUS)
        {
            verificarNRSUS = Program.ObterValor<int>("Digite o numero de registro do SUS: \n");

            Paciente Vericador = (Paciente)rP.registroGeral.FirstOrDefault(RegistroSUS => Paciente.RegistroSUS == verificarNRSUS);

            if (Vericador == null)
                return false;

            Console.WriteLine("NRSUS encontrado!");

            return true;
        }

    }
}
