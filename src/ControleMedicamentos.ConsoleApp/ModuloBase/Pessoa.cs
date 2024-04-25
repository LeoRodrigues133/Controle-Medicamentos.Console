namespace ControleMedicamentos.ConsoleApp.ModuloBase
{
    public class Pessoa : Entidade
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataDeNascimento { get; set; }



        public Pessoa(int id, string nome, string cpf, string endereco, DateTime dataDeNascimento) : base(id)
        {
            Cpf = cpf;
            Nome = nome;
            Endereco = endereco;
            DataDeNascimento = dataDeNascimento;
        }
    } 
}
