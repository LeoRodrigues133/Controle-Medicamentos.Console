using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloBase;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa
{
    public class Paciente : Pessoa
    {
        //public int IdPaciente = 1;
        public int RegistroSUS { get; set; }
        public static int idPaciente = 1;
        public Paciente(string nome, int registroSUS, string cpf, string endereco, DateTime dataDeNascimento) : base(nome, cpf, endereco, dataDeNascimento)
        {
            Id = idPaciente++;
            RegistroSUS = registroSUS;
        }
    }
}