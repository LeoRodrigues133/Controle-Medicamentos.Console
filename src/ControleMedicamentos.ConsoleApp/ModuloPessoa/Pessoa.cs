using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa
{
    public class Pessoa
    {
        public string cpf, nome, endereco;
        public DateTime dataDeNascimento;

        public Pessoa(string nome, string cpf, string endereco, DateTime dataDeNascimento)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.endereco = endereco;
            this.dataDeNascimento = dataDeNascimento;
        }
    }
}
