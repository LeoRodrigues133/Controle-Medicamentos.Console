using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloBase;
using ControleMedicamentos.ConsoleApp.ModuloRequisição;

namespace ControleMedicamentos.ConsoleApp.ModuloPessoa
{
    public class InterfacePessoas
    {
        public Entidade entidade;
        public Paciente paciente;
        public RepositorioPessoas rPessoas;
        public Menu menu;
        public DominioPessoas dominio;
        public DominioRequisicao dominioRequisicao;
        public InterfacePessoas(RepositorioPessoas rPessoas, DominioPessoas dominio)
        {
            this.dominio = dominio;
            this.rPessoas = rPessoas;
        }
        public void MenuCadastrarPaciente(DominioPessoas dominio, Paciente id, DominioRequisicao dominioRequisicao)
        {

            Console.Clear();
            Console.WriteLine("Cadastro de Paciente");


            string nome = Program.ObterValor<string>("Digite o nome do Paciente:\n");
            string cpf = Program.ObterValor<string>("CPF:\n");

            while (!dominio.VerificarCpf(cpf, rPessoas))
                cpf = Program.ObterValor<string>("CPF:\n");

            string endereco = Program.ObterValor<string>("cep:\n");
            int registroSUS = Program.ObterValor<int>("SUS:\n");

            while (!dominioRequisicao.VerificarNRSUS(registroSUS, rPessoas, dominioRequisicao))
                registroSUS = Program.ObterValor<int>("SUS:\n");

            DateTime dataDeNascimento = Program.ObterValor<DateTime>("Digite DDNascimento: \n");

            Paciente novoPaciente = new(nome, registroSUS, cpf, endereco, dataDeNascimento);
            rPessoas.CadastrarPessoa(novoPaciente, rPessoas);

        }


        public void MenuAtualizarPessoas(int Seletor)
        {
            rPessoas.MenuVerPessoas(rPessoas, dominio);

            Atualizar(Seletor);
        }
        public void Atualizar(int Seletor)
        {
            Paciente Verificador = rPessoas.RegistroPessoas
                .FirstOrDefault(P => P.Id == Seletor);

            if (Verificador == null)
                Console.WriteLine("Nenhum Paciente encontrado!");
            else
            {
                MenuSelecionarPaciente(Verificador, dominio);
            }
        }

        public void MenuSelecionarPaciente(Paciente Verificador, DominioPessoas dominio)
        {
            int opcao = Program.ObterValor<int>("Selecione o campo que deseja editar:\n1 - Nome\n2 - Endereço\n3 - Data de nascimento\n0 - Sair \nDigite: ");

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


        public void MenuExluirPessoa(int Seletor)
        {

            dominio.Excluir(Seletor);
        }

    }
}