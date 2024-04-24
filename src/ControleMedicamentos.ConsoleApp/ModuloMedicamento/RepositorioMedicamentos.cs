namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamentos
    {
        public List<Medicamento> estoque = new List<Medicamento>();
        public Medicamento medicamento;

        public void AdicionarMedicamento()
        {

            Console.Clear();
            Console.WriteLine("Cadastro de medicamento");

            string nome = Program.ObterValor<string>("Digite o nome do medicamento:\n").ToLower();
            string descricao = Program.ObterValor<string>("Descrição do medicamento:\n");
            int quantidadeInicial = Program.ObterValor<int>("Quantidade de medicamentos adicionados:\n");
            DateTime validade = Program.ObterValor<DateTime>("Digite a validade do medicamento (dd/mm/yyyy):\n");

            if (Medicamento.VerificarValidade(validade))
            {
                VerificarMedicamento(nome, descricao, quantidadeInicial, validade);
            }
        }

        private void GuardarMedicamento(Medicamento medicamento)
        {
            estoque.Add(medicamento);
        }
        public bool VerificarMedicamento(string nome, string descricao, int quantidadeInicial, DateTime validade)
        {
            Medicamento verificador = estoque.FirstOrDefault(m => m.nome == nome);

            if (verificador == null)
            {
                Medicamento novoMedicamento = new Medicamento(nome, descricao, quantidadeInicial, validade);

                estoque.Add(novoMedicamento);
                return false;
            }
            else
            {
                verificador.quantidade += quantidadeInicial;
                return true;
            }
        }

        public void VerificarEstoque()
        {

            foreach (var medicamento in estoque)
            {
                Console.WriteLine($"| {medicamento.nome}".PadRight(19) +
                                  $"| {medicamento.descricao}".PadRight(30) +
                                  $"| {medicamento.quantidade}".PadRight(7) +
                                  $"| {medicamento.validade.ToShortDateString()}".PadRight(12) +
                                  " |");
            }
            Console.ReadKey();
        }
        //        public Medicamento(string nome, string descricao, int quantidade, datetime validade)

        public void AtualizarEstoque() { }

        public void ExcluirMedicamento() { }
       
    }
}
