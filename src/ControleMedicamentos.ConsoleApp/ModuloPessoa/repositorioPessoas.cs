using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;

namespace ControleMedicamentos.ConsoleApp.ModuloPessoa
{
    public class RepositorioPessoas
    {
        public Pessoa pessoa;
        public List<Pessoa> registroGeral = new List<Pessoa>();


        public void CadastrarPessoa()
        {

            Console.Clear();
            Console.WriteLine("Cadastro de medicamento");

            string nome = Program.ObterValor<string>("Digite o nome da Pessoa:\n");
            string cpf = Program.ObterValor<string>("CPF:\n");
            string endereco = Program.ObterValor<string>("cep:\n");
            DateTime dataDeNascimento = Program.ObterValor<DateTime>("Digite DDNascimento: \n");

            VerificarCpf(nome, cpf, endereco, dataDeNascimento);
            VerificarRegistroGeral();
        }
        private void RegistrarPessoa(Pessoa pessoa)
        {
            registroGeral.Add(pessoa);
        }
        public bool VerificarCpf(string nome, string novoCpf, string endereco, DateTime dataDeNascimento)
        {
            Pessoa verificador = registroGeral.FirstOrDefault(p => p.Cpf == novoCpf);

            if (verificador == null)
            {
                Pessoa novaPessoa = new Pessoa(nome, novoCpf, endereco, dataDeNascimento);

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
    }
}
