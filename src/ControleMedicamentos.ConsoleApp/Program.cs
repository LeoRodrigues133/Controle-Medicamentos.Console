using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloBase;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloRequisição;

namespace Controle_de_Medicamentos_2024_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Controle de Medicamentos | Academia de Programação 2024!\n");

            DominioPessoas dPessoas = new DominioPessoas();
            DominioMedicamentos dMedicamentos = new DominioMedicamentos();
            RepositorioMedicamentos repositorioMedicamentos = new RepositorioMedicamentos();
            RepositorioPessoas repositorioPessoas = new RepositorioPessoas();
            Entidade e = new();

            #region Objetos Test
            Paciente p = new(e.Id, "Paciente Teste", 123456789, "123.123.123-23", "Jão da curva", DateTime.Now);
            repositorioPessoas.registroGeral.Add(p);
            Medicamento m = new(e.Id, "dipirona", "Se dor", 1, new DateTime(01 / 12 / 2000));
            repositorioMedicamentos.estoque.Add(m);
            Requisicao requisicao = new Requisicao(e.Id);
            #endregion

            InterfacePessoas uiPessoas = new InterfacePessoas(repositorioPessoas);
            InterfaceMedicamentos uiMedicamentos = new InterfaceMedicamentos(repositorioMedicamentos);

            Menu menu = new Menu(repositorioMedicamentos, repositorioPessoas, uiPessoas,uiMedicamentos, m, p, dPessoas, dMedicamentos);

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
