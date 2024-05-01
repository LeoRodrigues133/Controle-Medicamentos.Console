using Controle_de_Medicamentos_2024_ConsoleApp;

namespace ControleMedicamentos.ConsoleApp.ModuloBase
{
    public class Repositorio
    {
        public List<Entidade> registroGeral1 = new List<Entidade>();

        public Entidade entidade;
        public void Cadastrar()
        {
            
        }
        //public Paciente(int id, string nome, int registroSUS, string cpf, string endereco, DateTime dataDeNascimento)


        public void PassarValorID(string nome, int registroSUS, string novoCpf, string endereco, DateTime dataDeNascimento)
        {
            PassarValoresPessoa(entidade.Id);
        }
        public void PassarValoresPessoa(int id)
        {
            string nome = Program.ObterValor<string>("Digite o nome do Paciente:\n");
            string cpf = Program.ObterValor<string>("CPF:\n");
            string endereco = Program.ObterValor<string>("cep:\n");
            int registroSUS = Program.ObterValor<int>("SUS:\n");
            DateTime dataDeNascimento = Program.ObterValor<DateTime>("Digite DDNascimento: \n");

            PassarValorID(nome, registroSUS, cpf, endereco, dataDeNascimento);
        }

    }
}
