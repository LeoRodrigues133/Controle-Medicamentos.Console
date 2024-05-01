using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloBase;

namespace ControleMedicamentos.ConsoleApp.ModuloPessoa
{
    public class InterfacePessoas
    {
        public Entidade entidade;
        public Paciente paciente;
        public RepositorioPessoas rPessoas;
        public Menu menu;
        public DominioPessoas dominio;

        public InterfacePessoas(RepositorioPessoas rPessoas)
        {
            this.rPessoas = rPessoas;
        }
        public void MenuCadastrarPaciente(DominioPessoas dominio, Paciente id)
        {

            Console.Clear();
            Console.WriteLine("Cadastro de Paciente");


            string nome = Program.ObterValor<string>("Digite o nome do Paciente:\n");
            string cpf = Program.ObterValor<string>("CPF:\n");
            string endereco = Program.ObterValor<string>("cep:\n");
            int registroSUS = Program.ObterValor<int>("SUS:\n");
            DateTime dataDeNascimento = Program.ObterValor<DateTime>("Digite DDNascimento: \n");

            if (dominio.VerificarCpf(cpf, rPessoas))
            {
                Paciente novoPaciente = new(id.Id, nome, registroSUS, cpf, endereco, dataDeNascimento);
                rPessoas.registroGeral.Add(novoPaciente);
            }
        }


        public void MenuAtualizarPessoas()
        {
            int Seletor = Program.ObterValor<int>("Selecione um ID: ");

            Atualizar(Seletor);
        }
        public void Atualizar(int Seletor)
        {
            Paciente Verificador = (Paciente)rPessoas.registroGeral.FirstOrDefault(P => P.Id == Seletor);

            if (Verificador == null)
                Console.WriteLine("Nenhum Paciente encontrado!");
            else
            {
                SelecionarPaciente(Verificador);
            }
        }

        public void SelecionarPaciente(Paciente Verificador)
        {
            int opcao = Program.ObterValor<int>("Selecione o campo que deseja editar:\n1 - Nome\n2 - Descrição\n3 - Validade\n0 - Sair \nDigite: ");

            switch (opcao)
            {
                case 1:
                    string novoNome = Program.ObterValor<string>("Nome: ");

                    dominio.EditarNome(Verificador, novoNome);
                    break;
                case 2:

                    string novoEndereco = Program.ObterValor<string>("Endereço: ");

                    dominio.EditarEndereco(Verificador, novoEndereco);
                    break;
                case 3:

                    DateTime novaDDN = Program.ObterValor<DateTime>("Validade: ");

                    dominio.EditarDDN(Verificador, novaDDN);
                    break;
                case 0:
                    menu.MenuPessoas();
                    break;
            }
        }


        public void MenuExluirPessoa()
        {
            int Seletor = Program.ObterValor<int>("Digite um ID: ");

            dominio.Excluir(Seletor);
        }



    }
}