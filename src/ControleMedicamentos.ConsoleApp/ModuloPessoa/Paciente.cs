using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloBase;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa
{
    public class Paciente : Entidade
    {
        public Requisicao requisicaoMedicamentos;
        public int RegistroSUS { get; set; }

        // Correção do construtor
        public Paciente(int registroSUS, int id, string nome, string cpf, string endereco, DateTime dataDeNascimento) : base(id, nome, cpf, endereco, dataDeNascimento)
        {
            RegistroSUS = registroSUS;
        }

        protected void FazerRequisicao()
        {

        }
    }
}