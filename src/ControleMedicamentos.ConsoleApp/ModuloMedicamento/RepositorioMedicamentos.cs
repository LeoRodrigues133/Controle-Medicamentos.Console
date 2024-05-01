using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamentos
    {
        public List<Medicamento> estoque = new List<Medicamento>();
        public Medicamento medicamento;
        public Menu menu;
        public DominioMedicamentos dominio;

        public void Adicionar(DateTime validade,Medicamento medicamento, RepositorioMedicamentos rMedicamentos)
        {

            if (Medicamento.VerificarValidade(validade))
            {
                estoque.Add(medicamento);
                MenuVerificarMedicamentos(rMedicamentos);
            }
        } //Create

        public void MenuVerificarMedicamentos(RepositorioMedicamentos rMedicamentos )
        {
            Console.Clear();

            foreach ( Medicamento medicamento in rMedicamentos.estoque)

            Console.WriteLine($"| {medicamento.Id}".PadRight(5) +
                                        $"| {medicamento.Nome}".PadRight(19) +
                                        $"| {medicamento.Descricao}".PadRight(30) +
                                        $"| {medicamento.Quantidade}".PadRight(7) +
                                        $"| {medicamento.Validade.ToShortDateString()}".PadRight(12) +
                                        " |");
            Console.ReadKey();
        }
        //public void VerificarEstoque()
        //{

        //    foreach (Medicamento medicamento in estoque)
        //    {
        //        MenuVerificarMedicamentos(medicamento);
        //    }
        //    Console.ReadKey();
        //} // Read

        public void Atualizar(int Seletor, DominioMedicamentos dominio)
        {

            Medicamento Verificador = estoque.FirstOrDefault(M => M.Id == Seletor);

            if (Verificador == null)
                Console.WriteLine("Nenhum medicamento encontrado!");
            else
            {
                dominio.MenuSelecionarMedicamento(Verificador);
            }

            //        public Medicamento(int id, string nome, string descricao, int quantidade, datetime validade)
        } // Update

        public void ExcluirMedicamento(int Seletor, RepositorioMedicamentos repositorioMedicamentos)
        {
            MenuVerificarMedicamentos(repositorioMedicamentos);

            Medicamento Verificador = (Medicamento)estoque.FirstOrDefault(M => M.Id == Seletor);

            if (Verificador == null)
                Console.WriteLine("Nenhum medicamento encontrado!");

            else
            {
                estoque.Remove(Verificador);
            }
        } // Delete

    }
}
