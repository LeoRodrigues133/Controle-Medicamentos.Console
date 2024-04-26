using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa
{
    public class Paciente : Pessoa
    {
        public Requisicao requisicaoMedicamentos;
        public static int RegistroSUS { get; set; }

        public Paciente(int registroSUS, string nome, string cpf, string endereco, DateTime dataDeNascimento) : base(nome, cpf, endereco, dataDeNascimento)
        {
            RegistroSUS = registroSUS;
        }

        protected void FazerRequisicao()
        {

        }
    }
}