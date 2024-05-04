using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloRequisição;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class InterfaceRequisicao
    {
        private RepositorioMedicamentos rMedicamentos;
        private RepositorioPessoas rPessoas;
        private RepositorioRequisicao rRequisicao;

        public InterfaceRequisicao(RepositorioMedicamentos repositorioMedicamentos, RepositorioPessoas repositorioPessoas, RepositorioRequisicao repositorioRequisicao)
        {
            rMedicamentos = repositorioMedicamentos;
            rPessoas = repositorioPessoas;
            rRequisicao = repositorioRequisicao;
        }
        public void ProcessarRequisicao(DominioRequisicao dRequisicao, DominioMedicamentos dMedicamentos, RepositorioRequisicao rRequisicao, RepositorioPessoas rPessoas)
        {
            Paciente paciente = SelecionarPaciente(dRequisicao, rPessoas);
            Medicamento medicamento = SelecionarMedicamento(dRequisicao, rMedicamentos, dMedicamentos);
            int quantidadeSolicitada = Program.ObterValor<int>("Digite a quantidade solicitada:\n");


            if (medicamento != null && quantidadeSolicitada > 0)
            {
                CriarRequisicao(paciente.Nome, paciente.RegistroSUS, medicamento.Nome, quantidadeSolicitada, rRequisicao, rPessoas, dRequisicao);
                Console.WriteLine("Requisição processada com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao processar a requisição.");
            }
        }
        private Paciente SelecionarPaciente(DominioRequisicao dRequisicao, RepositorioPessoas rPessoas)
        {
            dRequisicao.VerPacientes(rPessoas);
            int registroSUS = Program.ObterValor<int>("Digite o número do registro SUS do paciente:\n");

            while (!dRequisicao.VerificarNRSUS(registroSUS, rPessoas))
                registroSUS = Program.ObterValor<int>("Digite o número do registro SUS do paciente:\n");

            return rPessoas.RegistroPessoas.FirstOrDefault(p => p.RegistroSUS == registroSUS);
        }
        public Medicamento SelecionarMedicamento(DominioRequisicao dRequisicao, RepositorioMedicamentos rMedicamentos, DominioMedicamentos dMedicamentos)
        {
            dRequisicao.VerMedicamentos(rMedicamentos, dMedicamentos);
            string nomeMedicamento = Program.ObterValor<string>("Digite o nome do medicamento:\n");

            while (!dRequisicao.BuscarMedicamento(nomeMedicamento, rMedicamentos))
                nomeMedicamento = Program.ObterValor<string>("Digite o nome do medicamento: \n");

            return rMedicamentos.estoque.FirstOrDefault(m => m.Nome == nomeMedicamento);
        }
        private Requisicao SelecionarRequisicao(DominioRequisicao dRequisicao, RepositorioRequisicao rRequisicao, Medicamento medicamento, Requisicao requisicao, Paciente paciente, RepositorioMedicamentos estoqueMedicamentos, RepositorioPessoas registroPessoas)
        {
            int IdBuscador = Program.ObterValor<int>("Selecione um ID:");
            dRequisicao.AceitarRequisicao(IdBuscador, registroPessoas, estoqueMedicamentos, paciente, dRequisicao, rRequisicao);


            return rRequisicao.registroRequisicao.FirstOrDefault(m => m.IdRequisicao == IdBuscador);

        }

        private void CriarRequisicao(string nome, int registroSUS, string medicamento, int quantidade, RepositorioRequisicao rRequisicao, RepositorioPessoas rPessoas, DominioRequisicao dRequisicao)
        {
            Requisicao novaRequisicao = new Requisicao(nome, registroSUS, medicamento, quantidade);
            rRequisicao.GuardarRequisicao(rPessoas, rRequisicao, rMedicamentos, novaRequisicao, dRequisicao);
        }

        public void MenuGerenciamentoRequisicoes(RepositorioPessoas registroPessoas, RepositorioMedicamentos estoqueMedicamentos, Paciente paciente, Medicamento medicamento, DominioRequisicao dRequisicao, RepositorioRequisicao rRequisicao, Requisicao requisicao)
        {
            rRequisicao.VerRequisicao(rRequisicao, registroPessoas, estoqueMedicamentos, paciente, medicamento, dRequisicao);

            SelecionarRequisicao(dRequisicao, rRequisicao, medicamento, requisicao, paciente, estoqueMedicamentos, registroPessoas);
            //int IdBuscador = Program.ObterValor<int>("Selecione um ID:");
            //while (!dRequisicao.AceitarRequisicao(IdBuscador, registroPessoas, estoqueMedicamentos, paciente, medicamento, dRequisicao, rRequisicao))
            //    IdBuscador = Program.ObterValor<int>("Selecione um ID:");


        }

        public bool MenuGestaoRequisicao()
        {
            int opcao = Program.ObterValor<int>("Selecione uma opção para a Requisição:\n 1 - Aceitar Requisição\n 2 - Rejeitar Requisição\n Digite:\n");
            if (opcao == 2)
            {
                Console.WriteLine("Requisição rejeitada com sucesso!");
                return false;
            }

            Console.WriteLine("Requisição aceita com sucesso!");
            return true;
        }
    }
}

