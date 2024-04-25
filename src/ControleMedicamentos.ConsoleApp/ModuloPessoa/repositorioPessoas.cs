using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloBase;

namespace ControleMedicamentos.ConsoleApp.ModuloPessoa
{
    public class RepositorioPessoas
    {
        public Paciente pessoa;
        public List<Paciente> registroGeral = new List<Paciente>();


        public void CadastrarPessoa()
        {

            Console.Clear();
            Console.WriteLine("Cadastro de medicamento");

            string nome = Program.ObterValor<string>("Digite o nome da Pessoa:\n");
            string cpf = Program.ObterValor<string>("CPF:\n");
            string endereco = Program.ObterValor<string>("cep:\n");
            int registroSUS = Program.ObterValor<int>("SUS:\n");
            DateTime dataDeNascimento = Program.ObterValor<DateTime>("Digite DDNascimento: \n");

            VerificarCpf(registroSUS ,nome, cpf, endereco, dataDeNascimento);
            VerificarRegistroGeral();
        }
        private void RegistrarPessoa(Paciente pessoa)
        {
            registroGeral.Add(pessoa);
        }
        public bool VerificarCpf(int registroSUS, string nome, string novoCpf, string endereco, DateTime dataDeNascimento)
        {
            Paciente verificador = registroGeral.FirstOrDefault(p => p.Cpf == novoCpf);

            if (verificador == null)
            {
                Paciente novaPessoa = new Paciente(pessoa.Id, registroSUS ,nome, novoCpf, endereco, dataDeNascimento);

                RegistrarPessoa(novaPessoa);
                return false;
            }
            Console.WriteLine("Esta Pessoa já esta cadastrada!");
            Console.ReadKey();
            return true;
        }


        public void VerificarRegistroGeral()
        {

            Console.Clear();

            foreach (var pessoa in registroGeral)
            {
                Console.WriteLine($"| {pessoa.Nome}".PadRight(10) +
                                  $"| {pessoa.Cpf}".PadRight(17) +
                                  $"| {pessoa.Endereco}".PadRight(12) +
                                  $"| {pessoa.DataDeNascimento.ToShortDateString()}".PadRight(10) +
                                  " |");
            }
            Console.ReadKey();
        }

        public bool ValidarPaciente(int NRSUS)
        {
            Paciente Verificador = registroGeral.FirstOrDefault(requisitor => requisitor.RegistroSUS == NRSUS);

            if (Verificador == null)
            {
                Console.WriteLine($"Numero de Registro SUS: {NRSUS}. Não encontrado!");
                return false;
            }

            Console.WriteLine("Deu certo");
            return true;
        }
    }
}
