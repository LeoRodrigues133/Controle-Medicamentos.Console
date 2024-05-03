using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloBase;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa
{
    public class Pessoa : Entidade
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataDeNascimento { get; set; }



        public Pessoa(string nome, string cpf, string endereco, DateTime dataDeNascimento) : base()
        {
            Cpf = cpf;
            Nome = nome;
            Endereco = endereco;
            DataDeNascimento = dataDeNascimento;
        }
    }
}
