using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;

namespace Controle_de_Medicamentos_2024_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Controle de Medicamentos | Academia de Programação 2024!\n");
            RepositorioMedicamentos repositorioMedicamentos = new RepositorioMedicamentos();
            RepositorioPessoas repositorioPessoas = new RepositorioPessoas();
            Menu menu = new Menu(repositorioMedicamentos, repositorioPessoas);

            menu.menu();
        }

        #region Métodos da Main
        public static tipo ObterValor<tipo>(string texto)
        {
            Console.Write(texto);

            string input = Console.ReadLine();

            try
            {
                return (tipo)Convert.ChangeType(input, typeof(tipo));
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido!");
                return ObterValor<tipo>(texto);
            }
        }
        #endregion
    }
}
