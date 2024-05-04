using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloRequisição;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;
using System.Security.Cryptography.X509Certificates;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface
{
    public class Menu
    {
        public RepositorioMedicamentos estoqueMedicamentos;
        public RepositorioPessoas registroPessoas;
        public RepositorioRequisicao rRequisicao;
        public Requisicao requisicao;

        public InterfacePessoas uiPessoas;
        public InterfaceMedicamentos uiMedicamentos;
        public InterfaceRequisicao uiRequisicao;

        public Medicamento medicamento;
        public Paciente paciente;

        public DominioPessoas dPessoas;
        public DominioMedicamentos dMedicamentos;
        public DominioRequisicao dRequisicao;

        public Menu(RepositorioMedicamentos estoque, RepositorioPessoas registro, RepositorioRequisicao rRequisicao, InterfacePessoas uiPessoas, InterfaceMedicamentos uiMedicamentos, InterfaceRequisicao uiRequisicao, Paciente pTest, Medicamento mTest, DominioPessoas dPessoas, DominioMedicamentos dMedicamentos, DominioRequisicao dRequisicao)
        {
            this.estoqueMedicamentos = estoque;
            this.registroPessoas = registro;
            this.uiPessoas = uiPessoas;
            this.rRequisicao = rRequisicao;
            this.uiMedicamentos = uiMedicamentos;
            this.uiRequisicao = uiRequisicao;
            this.paciente = pTest;
            this.medicamento = mTest;
            this.dPessoas = dPessoas;
            this.dMedicamentos = dMedicamentos;
            this.dRequisicao = dRequisicao;
        }

        public void MenuInicial()
        {
            while (true)
            {
                Console.WriteLine("MENU INICIAL");
                Console.WriteLine("Escolha uma opção: \n1 - Cadastrar Medicamentos\n2 - Cadastrar Pessoas\n3 - Menu de Paciente **(Usar para fazer requisição no balcão)**\n4 - Menu de Funcionário **(Usar para administrar requisições)**\n0 - Sair\n\n");

                int opcao = Program.ObterValor<int>("Digite:\n");

                switch (opcao)
                {
                    case 1:
                        MenuMedicamentos();
                        break;
                    case 2:
                        MenuPessoas();
                        break;
                    case 3:
                        MenuRequisicao(uiRequisicao);
                        break;
                    case 4:
                        MenuAtendimento();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
        public void MenuMedicamentos()
        {
            while (true)
            {
                Console.WriteLine("CADASTRO DE MEDICAMENTOS!");
                Console.WriteLine("Escolha uma opção: \n1 - Cadastro\n2 - Ver Estoque\n3 - Atualizar Estoque\n4 - Excluir Item\n0 - Sair\n\n");

                int opcao = Program.ObterValor<int>("Digite:\n");
                int Seletor;
                switch (opcao)
                {
                    case 1:
                        uiMedicamentos.MenuAdicionarMedicamentos(dMedicamentos, medicamento, estoqueMedicamentos);
                        break;
                    case 2:
                        MenuEstoque();
                        break;
                    case 3:
                        Seletor = Program.ObterValor<int>("Selecione um ID: ");

                        uiMedicamentos.MenuAtualizarMedicamento(Seletor, dMedicamentos);
                        break;
                    case 4:
                        Seletor = Program.ObterValor<int>("Selecione um ID para excluir:");

                        estoqueMedicamentos.ExcluirMedicamento(Seletor, estoqueMedicamentos);
                        break;
                    case 0:
                        MenuInicial();

                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
        public void MenuPessoas()
        {
            Console.WriteLine("CADASTRO DE PESSOAS!");
            while (true)
            {
                Console.WriteLine("Escolha uma opção: \n1 - Cadastro\n2 - Ver Estoque\n3 - Atualizar Estoque\n4 - Excluir Item\n0 - Sair\n\n");

                int opcao = Program.ObterValor<int>("Digite:\n");
                int Seletor;
                switch (opcao)
                {
                    case 1:
                        uiPessoas.MenuCadastrarPaciente(dPessoas, paciente, dRequisicao);
                        break;
                    case 2:
                        registroPessoas.MenuVerPessoas(registroPessoas, dPessoas);
                        break;
                    case 3:
                        Seletor = Program.ObterValor<int>("Selecione o ID que deseja atualizar: ");

                        uiPessoas.MenuAtualizarPessoas(Seletor);
                        break;
                    case 4:
                        Seletor = Program.ObterValor<int>("Digite o ID que deseja deletar: ");

                        uiPessoas.MenuExluirPessoa(Seletor);
                        break;
                    case 0:
                        MenuInicial();
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        public void MenuRequisicao(InterfaceRequisicao uiRequisicao)
        {
            Console.WriteLine("ATENDIMENTO DE UNIDADE DE SAÚDE!");
            while (true)
            {
                Console.WriteLine("Escolha uma opção: \n1 - Fazer Pedido de medicamento\n0 - Sair\n\n");

                int opcao = Program.ObterValor<int>("Digite:\n");

                switch (opcao)
                {
                    case 1:
                        uiRequisicao.ProcessarRequisicao(dRequisicao, dMedicamentos, rRequisicao, registroPessoas);
                        break;
                    case 0:
                        MenuInicial();

                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        public void MenuAtendimento()
        {
            Console.WriteLine("Menu de atendimento ao paciente!");
            while (true)
            {
                Console.WriteLine("Escolha uma opção:\n1 - Ver histórico de requisições\n2 - Gestão de Requisições\n3 - Recusar requisição\n0 - Sair\n\n");
                int opcao = Program.ObterValor<int>("Digite:");

                switch (opcao)
                {
                    case 1:
                        rRequisicao.VerRequisicao(rRequisicao, registroPessoas, estoqueMedicamentos, paciente, medicamento, dRequisicao);
                        break;
                    case 2:
                        uiRequisicao.MenuGerenciamentoRequisicoes(registroPessoas, estoqueMedicamentos, paciente, medicamento, dRequisicao, rRequisicao,requisicao);
                        break;
                    case 3: break;
                    case 0:
                        MenuInicial();
                        break;
                }
            }
        }

        public void MenuEstoque()
        {
            Console.WriteLine("Menu de Gerenciamento do estoque");
            while (true)
            {
                Console.WriteLine("Escolha uma opção: \n1 - Verificar estoque\n2 - Verificar quantidade crítica\n3 - Verificar medicamentos em falta\n0 - Sair\n\n");

                int opcao = Program.ObterValor<int>("Digite:\n");

                switch (opcao)
                {
                    case 1:
                        estoqueMedicamentos.MostrarTodoEstoque(estoqueMedicamentos, dMedicamentos);
                        break;
                    case 2:
                        estoqueMedicamentos.MostrarEstoqueCritico(estoqueMedicamentos, dMedicamentos);
                        break;
                    case 3:
                        estoqueMedicamentos.MostrarFaltaEstoque(estoqueMedicamentos, dMedicamentos);
                        break;
                    case 0:
                        MenuMedicamentos();

                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
        public bool Continua(int opcao)
        {
            if (opcao == 0)
                return false;
            return true;
        }
    }

}
