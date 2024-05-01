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
        public InterfaceRequisito uiRequisicao;

        public Medicamento mTest;
        public Paciente pTest;

        public DominioPessoas dPessoas;
        public DominioMedicamentos dMedicamentos;
        public DominioRequisicao dRequisicao;

        public Menu(RepositorioMedicamentos estoque, RepositorioPessoas registro, InterfacePessoas uiPessoas,InterfaceMedicamentos uiMedicamentos, Medicamento mTest, Paciente pTest, DominioPessoas dPessoas, DominioMedicamentos dMedicamentos)
        {
            this.estoqueMedicamentos = estoque;
            this.registroPessoas = registro;
            this.uiPessoas = uiPessoas;
            this.uiMedicamentos = uiMedicamentos;
            this.pTest = pTest;
            this.mTest = mTest;
            this.dPessoas = dPessoas;
            this.dMedicamentos = dMedicamentos;
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
                        MenuRequisicao();
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
                        uiMedicamentos.MenuAdicionarMedicamentos(dMedicamentos,mTest, estoqueMedicamentos);
                        break;
                    case 2:
                        estoqueMedicamentos.MenuVerificarMedicamentos(estoqueMedicamentos);
                        break;
                    case 3:
                        uiMedicamentos.MenuAtualizarMedicamento(dMedicamentos);
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

                switch (opcao)
                {
                    case 1:
                        uiPessoas.MenuCadastrarPaciente(dPessoas, pTest);
                        break;
                    case 2:
                        registroPessoas.MenuVerPessoas(registroPessoas);
                        break;
                    case 3:
                        uiPessoas.MenuAtualizarPessoas();
                        break;
                    case 4:
                        uiPessoas.MenuExluirPessoa();
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

        public void MenuRequisicao()
        {
            Console.WriteLine("ATENDIMENTO DE UNIDADE DE SAÚDE!");
            while (true)
            {
                Console.WriteLine("Escolha uma opção: \n1 - Fazer Pedido de medicamento\n0 - Sair\n\n");

                int opcao = Program.ObterValor<int>("Digite:\n");

                switch (opcao)
                {
                    case 1:
                        uiRequisicao.GerarRequisicao();
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
