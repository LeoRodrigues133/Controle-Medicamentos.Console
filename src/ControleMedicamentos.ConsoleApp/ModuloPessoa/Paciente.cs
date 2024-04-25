using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa
{
    public class Paciente : Pessoa
    {
        public Requisicao requisicaoMedicamentos;
        public int RegistroSUS { get; set; }

        // Correção do construtor
        public Paciente(int registroSUS, string nome, string cpf, string endereco, DateTime dataDeNascimento) : base(nome, cpf, endereco, dataDeNascimento)
        {
            RegistroSUS = registroSUS;
        }

        protected void FazerRequisicao()
        {

        }
    }
}