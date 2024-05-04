using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Globalization;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamentos
    {
        public List<Medicamento> estoque = new List<Medicamento>();
        public Medicamento medicamento;
        public Menu menu;
        public DominioMedicamentos dominio;

        public RepositorioMedicamentos(DominioMedicamentos dominio)
        {
            this.dominio = dominio;
        }
        public void Adicionar(Medicamento medicamento, RepositorioMedicamentos rMedicamentos)
        {
            estoque.Add(medicamento);
            MostrarTodoEstoque(rMedicamentos, dominio);
        } //Create

        public void MostrarTodoEstoque(RepositorioMedicamentos rMedicamentos, DominioMedicamentos dominio)
        {
            Console.Clear();
            dominio.Cabecalho();
            foreach (Medicamento medicamento in rMedicamentos.estoque)
            {
                if (medicamento.Quantidade > 0)
                {
                    {
                        Console.Write($"| {medicamento.Id}".PadRight(5) +
                                              $"| {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(medicamento.Nome)}".PadRight(19) +
                                              $"| {medicamento.Descricao}".PadRight(56) + "|");

                        dominio.VerificarQuantidadeEstoque(medicamento);

                        Console.WriteLine($"| {medicamento.Validade.ToShortDateString()}".PadRight(11) + "|");
                        dominio.Rodape();
                    }
                }
            }
            Console.WriteLine("Pressione para continuar...");
            Console.ReadKey();
        }
        public void MostrarEstoqueCritico(RepositorioMedicamentos rMedicamentos, DominioMedicamentos dominio)
        {
            Console.Clear();
            dominio.Cabecalho();
            foreach (Medicamento medicamento in rMedicamentos.estoque)
            {
                if (medicamento.Quantidade <= 20 && medicamento.Quantidade > 0)
                {
                    {
                        Console.Write($"| {medicamento.Id}".PadRight(5) +
                                              $"| {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(medicamento.Nome)}".PadRight(19) +
                                              $"| {medicamento.Descricao}".PadRight(56) + "|");

                        dominio.VerificarQuantidadeEstoque(medicamento);
                        Console.WriteLine($"| {medicamento.Validade.ToShortDateString()}".PadRight(11) + "|");
                        dominio.Rodape();
                    }
                }
            }
            Console.WriteLine("Pressione para continuar...");
            Console.ReadKey();
        }
        public void MostrarFaltaEstoque(RepositorioMedicamentos rMedicamentos, DominioMedicamentos dominio)
        {
            Console.Clear();
            dominio.Cabecalho();
            foreach (Medicamento medicamento in rMedicamentos.estoque)
            {
                if (medicamento.Quantidade == 0)
                {
                    {
                        Console.Write($"| {medicamento.Id}".PadRight(5) +
                                              $"| {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(medicamento.Nome)}".PadRight(19) +
                                              $"| {medicamento.Descricao}".PadRight(56) + "|");

                        dominio.VerificarQuantidadeEstoque(medicamento);
                        Console.WriteLine();
                        dominio.Rodape();
                    }
                }
            }
            Console.WriteLine("Pressione para continuar...");
            Console.ReadKey();
        }
        public void AtualizarMedicamento(int Seletor, DominioMedicamentos dominio, RepositorioMedicamentos repositorioMedicamentos)
        {
            MostrarTodoEstoque(repositorioMedicamentos, dominio);

            Medicamento Verificador = estoque.FirstOrDefault(M => M.Id == Seletor);

            if (Verificador == null)
                Console.WriteLine("Nenhum medicamento encontrado!");
            else
            {
                dominio.AtualizarCampo(Verificador);
            }

            //        public Medicamento(int id, string nome, string descricao, int quantidade, datetime validade)
        } // Update

        public void ExcluirMedicamento(int Seletor, RepositorioMedicamentos repositorioMedicamentos)
        {
            MostrarTodoEstoque(repositorioMedicamentos, dominio);
            Medicamento Verificador = estoque.FirstOrDefault(M => M.Id == Seletor);

            if (Verificador == null)
                Console.WriteLine("Nenhum medicamento encontrado!");

            else
            {
                estoque.Remove(Verificador);
            }
        } // Delete

    }
}
