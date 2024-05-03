using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloRequisição;
using System.Security.Cryptography.X509Certificates;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface
{
    public class Menu
    {
        public RepositorioMedicamentos estoqueMedicamentos;
        public RepositorioPessoas registroPessoas;
        public Requisicao requisicao;

        public InterfacePessoas uiPessoas;
        public InterfaceMedicamentos uiMedicamentos;
        public InterfaceRequisicao uiRequisicao;

        public Medicamento medicamento;
        public Paciente pTest;

        public DominioPessoas dPessoas;
        public DominioMedicamentos dMedicamentos;
        public DominioRequisicao dRequisicao;

        public Menu(RepositorioMedicamentos estoque, RepositorioPessoas registro, InterfacePessoas uiPessoas, InterfaceMedicamentos uiMedicamentos, InterfaceRequisicao uiRequisicao, Paciente pTest, DominioPessoas dPessoas, DominioMedicamentos dMedicamentos, DominioRequisicao dRequisicao)
        {
            this.estoqueMedicamentos = estoque;
            this.registroPessoas = registro;
            this.uiPessoas = uiPessoas;
            this.uiMedicamentos = uiMedicamentos;
            this.uiRequisicao = uiRequisicao;
            this.pTest = pTest;
            this.dPessoas = dPessoas;
            this.dMedicamentos = dMedicamentos;
            this.dRequisicao = dRequisicao;
        }

        public void MenuInicial()
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção: \n1 - Cadastrar Medicamentos\n2 - Cadastrar Pessoas\n3 - Requisição de Medicamentos\n0 - Sair\n\n");

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
                        estoqueMedicamentos.MenuVerificarMedicamentos(estoqueMedicamentos, dMedicamentos);
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
                        uiPessoas.MenuCadastrarPaciente(dPessoas, pTest, dRequisicao);
                        break;
                    case 2:
                        registroPessoas.MenuVerPessoas(registroPessoas);
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
                        uiRequisicao.GerarRequisicao(dRequisicao, pTest, registroPessoas, estoqueMedicamentos, dMedicamentos, medicamento);
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
        public bool Continua(int opcao)
        {
            if (opcao == 0)
                return false;
            return true;
        }
    }

}
