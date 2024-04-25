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
            Requisicao requisicao = new Requisicao(0);
            Menu menu = new Menu(repositorioMedicamentos, repositorioPessoas, requisicao);

            menu.MenuInicial();
        }

        #region Métodos da Main
        public static TIPO ObterValor<TIPO>(string texto)
        {
            Console.Write(texto);

            string input = Console.ReadLine();

            try
            {
                return (TIPO)Convert.ChangeType(input, typeof(TIPO));
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido!");
                return ObterValor<TIPO>(texto);
            }
        }
        #endregion
    }
}
