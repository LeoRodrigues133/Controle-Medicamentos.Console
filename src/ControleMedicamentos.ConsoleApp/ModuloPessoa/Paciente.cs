using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloBase;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa
{
    public class Paciente : Pessoa
    {
        public int IdPaciente = 1;
        public int RegistroSUS { get; set; }

        public Paciente(int id, string nome, int registroSUS, string cpf, string endereco, DateTime dataDeNascimento) : base(id, nome, cpf, endereco, dataDeNascimento)
        {
            IdPaciente = Entidade.ProximoIdPaciente();
            RegistroSUS = registroSUS;
        }

        protected void FazerRequisicao()
        {
            int proximoId = base.GerarNovoId(); // Chamada ao método GerarNovoId() da classe Entidade
            // Faça algo com o próximo ID obtido
        }
    }
}