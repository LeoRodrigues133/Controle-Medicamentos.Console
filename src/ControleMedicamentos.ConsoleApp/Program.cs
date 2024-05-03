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
            DominioRequisicao dRequisicao = new DominioRequisicao();
            RepositorioMedicamentos repositorioMedicamentos = new RepositorioMedicamentos(dMedicamentos);
            RepositorioPessoas repositorioPessoas = new RepositorioPessoas();
            Entidade e = new();

            #region Objetos Test
            Paciente p = new("Leonardo", 999, "1234", "Duarte da costa", new DateTime(1997,07,02));
            Paciente p1 = new("Leo", 998, "1235", "Duarte da costa", new DateTime(1997,07,02));
            Paciente p2 = new("Leandro", 997, "1236", "Duarte da costa", new DateTime(1997,07,02));
            repositorioPessoas.RegistroPessoas.Add(p);
            repositorioPessoas.RegistroPessoas.Add(p1);
            repositorioPessoas.RegistroPessoas.Add(p2);
            Medicamento m1 = new Medicamento("dipirona", "Analgésico e antipirético", 150, new DateTime(2025, 10, 01));
            Medicamento m2 = new Medicamento("dorflex", "Relaxante muscular com analgésico", 200, new DateTime(2024, 12, 01));
            Medicamento m3 = new Medicamento("paracetamol", "Para dor leve a moderada e febre", 300, new DateTime(2025, 08, 01));
            Medicamento m4 = new Medicamento("ibuprofeno", "Anti-inflamatório para dores e febres", 250, new DateTime(2025, 07, 01));
            Medicamento m5 = new Medicamento("amoxicilina", "Antibiótico de amplo espectro", 100, new DateTime(2024, 06, 01));
            Medicamento m6 = new Medicamento("losartana", "Medicamento para hipertensão", 120, new DateTime(2026, 01, 01));
            Medicamento m7 = new Medicamento("lasanha", "Medicamento para hipertensão", 10, new DateTime(2026, 01, 01));
            repositorioMedicamentos.estoque.Add(m1);
            repositorioMedicamentos.estoque.Add(m2);
            repositorioMedicamentos.estoque.Add(m3);
            repositorioMedicamentos.estoque.Add(m4);
            repositorioMedicamentos.estoque.Add(m5);
            repositorioMedicamentos.estoque.Add(m6);
            repositorioMedicamentos.estoque.Add(m7);

            Requisicao requisicao = new Requisicao(e.Id);
            #endregion

            InterfacePessoas uiPessoas = new InterfacePessoas(repositorioPessoas,dPessoas);
            InterfaceMedicamentos uiMedicamentos = new InterfaceMedicamentos(repositorioMedicamentos);
            InterfaceRequisicao uiRequisicao = new InterfaceRequisicao();

            Menu menu = new Menu(repositorioMedicamentos, repositorioPessoas, uiPessoas, uiMedicamentos, uiRequisicao, p, dPessoas, dMedicamentos, dRequisicao);

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
