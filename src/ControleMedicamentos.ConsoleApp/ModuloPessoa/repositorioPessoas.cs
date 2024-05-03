using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloBase;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;
using System.Globalization;

namespace ControleMedicamentos.ConsoleApp.ModuloPessoa
{
    public class RepositorioPessoas
    {
        public Menu menu;
        public Entidade entidade;
        public Paciente paciente;
        public InterfacePessoas uiPessoas;
        public DominioPessoas dominio;
        public RepositorioPessoas rPessoas;
        public List<Paciente> RegistroPessoas = new List<Paciente>();

        public void CadastrarPessoa(Paciente pessoa, RepositorioPessoas rPessoas) // Create
        {
            RegistroPessoas.Add(pessoa);
            MenuVerPessoas(rPessoas);
        }
        public void MenuVerPessoas(RepositorioPessoas rPessoas)
        {
            Console.Clear();

            foreach (Paciente paciente in rPessoas.RegistroPessoas)
            {
                Console.WriteLine($"| {paciente.Id}".PadRight(5) +
                                             $"| {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(paciente.Nome)}".PadRight(10) +
                                             $"| {paciente.Cpf}".PadRight(17) +
                                             $"| {paciente.Endereco}".PadRight(12) +
                                             $"| {paciente.RegistroSUS.ToString().PadRight(7)}" +
                                             $"| {paciente.DataDeNascimento.ToShortDateString()}".PadRight(10) +
                                              " |");
            }
            Console.WriteLine("Pressione para continuar...");
            Console.ReadKey();
        }
    }
}