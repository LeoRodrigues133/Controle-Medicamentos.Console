using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloBase;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;

namespace ControleMedicamentos.ConsoleApp.ModuloPessoa
{
    public class RepositorioPessoas
    {
        public Menu menu;
        public Paciente paciente;
        public List<Pessoa> registroGeral = new List<Pessoa>();


        public void CadastrarPessoa()
        {

            Console.Clear();
            Console.WriteLine("Cadastro de medicamento");

            string nome = Program.ObterValor<string>("Digite o nome da Pessoa:\n");
            string cpf = Program.ObterValor<string>("CPF:\n");
            string endereco = Program.ObterValor<string>("cep:\n");
            int registroSUS = Program.ObterValor<int>("SUS:\n");
            DateTime dataDeNascimento = Program.ObterValor<DateTime>("Digite DDNascimento: \n");

            VerificarCpf(registroSUS,nome, cpf, endereco, dataDeNascimento);
            VerificarRegistroGeral();
        }
        private void RegistrarPessoa(Pessoa pessoa)
        {
            registroGeral.Add(pessoa);
        }
        public bool VerificarCpf(int registroSUS, string nome, string novoCpf, string endereco, DateTime dataDeNascimento)
        {
            Paciente verificador = (Paciente)registroGeral.FirstOrDefault(p => p.Cpf == novoCpf);

            if (verificador == null)
            {
                Paciente novoPaciente = new Paciente(registroSUS, nome, novoCpf, endereco, dataDeNascimento);

                RegistrarPessoa(novoPaciente);
                return false;
            }
            Console.WriteLine("Esta Pessoa já esta cadastrada!");
            Console.ReadKey();
            return true;
        }


        public void VerificarRegistroGeral()
        {

            Console.Clear();

            foreach (Paciente paciente in registroGeral)
            {
                Console.WriteLine($"| {paciente.Id}".PadRight(5) +
                                  $"| {paciente.Nome}".PadRight(10) +
                                  $"| {paciente.Cpf}".PadRight(17) +
                                  $"| {paciente.Endereco}".PadRight(12) +
                                  $"| {Paciente.RegistroSUS.ToString().PadRight(7)}" +
                                  $"| {paciente.DataDeNascimento.ToShortDateString()}".PadRight(10) +
                                  " |");
            }
            Console.ReadKey();
        }

        public void AtualizarEstoque()
        {

            int Seletor = Program.ObterValor<int>("Selecione um ID: ");

            Paciente Verificador = (Paciente)registroGeral.FirstOrDefault(P => P.Id == Seletor);

            if (Verificador == null)
                Console.WriteLine("Nenhum Paciente encontrado!");
            else
            {
                SelecionarPaciente(Verificador);
            }

        }

        private void SelecionarPaciente(Paciente Verificador)
        {
            int opcao = Program.ObterValor<int>("Selecione o campo que deseja editar:\n1 - Nome\n2 - Descrição\n3 - Validade\n0 - Sair \nDigite: ");

            switch (opcao)
            {
                case 1:
                    string novoNome = Program.ObterValor<string>("Nome: ");

                    EditarNome(Verificador, novoNome);
                    break;
                case 2:

                    string novoEndereco = Program.ObterValor<string>("Endereço: ");

                    EditarEndereco(Verificador, novoEndereco);
                    break;
                case 3:

                    DateTime novaDDN = Program.ObterValor<DateTime>("Validade: ");

                    EditarDDN(Verificador, novaDDN);
                    break;
                case 0:
                    menu.MenuPessoas();
                    break;
            }
        }

        public bool EditarNome(Paciente pacienteEditado, string novoNome)
        {
            if (novoNome == null)
                return false;

            pacienteEditado.Nome = novoNome;
            return true;
        }
        public bool EditarEndereco(Paciente pacienteEditado, string novoEndereco)
        {
            if (novoEndereco == null)
                return false;

            pacienteEditado.Endereco = novoEndereco;
            return true;
        }

        public bool EditarDDN(Paciente pacienteEditado, DateTime novaDDN)
        {
            if(novaDDN == null)
                return false;

            pacienteEditado.DataDeNascimento = novaDDN;
            return true;
        }
        public void ExcluirMedicamento()
        {
            int Seletor = Program.ObterValor<int>("Digite um ID: ");

            Paciente Verificador = (Paciente)registroGeral.FirstOrDefault(M => M.Id == Seletor);

            if (Verificador == null)
                Console.WriteLine("Nenhum paciente encontrado!");

            else
            {
                registroGeral.Remove(Verificador);
            }
        }

    }
}
