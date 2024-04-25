using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;
using System.Security.Cryptography.X509Certificates;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface
{
    public class Menu
    {
        public RepositorioMedicamentos estoqueMedicamentos;
        public RepositorioPessoas registroPessoas;
        public Requisicao requisicao;

        public Menu(RepositorioMedicamentos estoque, RepositorioPessoas registro, Requisicao requisicao)
        {
            this.estoqueMedicamentos = estoque;
            this.registroPessoas = registro;
            this.requisicao = requisicao;
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

                switch (opcao)
                {
                    case 1:
                        estoqueMedicamentos.AdicionarMedicamento();
                        break;
                    case 2:
                        estoqueMedicamentos.VerificarEstoque();
                        break;
                    case 3:
                        estoqueMedicamentos.AtualizarEstoque();
                        break;
                    case 4:
                        estoqueMedicamentos.ExcluirMedicamento();
                        break;
                    case 0:
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
                        registroPessoas.CadastrarPessoa();
                        break;
                    case 2:
                        registroPessoas.VerificarRegistroGeral();
                        break;
                    case 3:
                        Console.WriteLine("Indisponível!");
                        break;
                    case 4:
                        Console.WriteLine("Indisponível!");
                        break;
                    case 0:
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
                        requisicao.GerarRequisicao();
                        break;
                    case 0:
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
