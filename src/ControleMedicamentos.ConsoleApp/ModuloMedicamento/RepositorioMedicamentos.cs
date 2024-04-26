using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamentos
    {
        public List<Medicamento> estoque = new List<Medicamento>();
        public Medicamento? medicamento;
        public Menu menu;

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
            Medicamento verificador = (Medicamento)estoque.FirstOrDefault(m => m.Nome == nome)!;

            if (verificador == null)
            {
                Medicamento novoMedicamento = new Medicamento(nome, descricao, quantidadeInicial, validade);

                GuardarMedicamento(novoMedicamento);
                return false;
            }
            else
            {
                verificador.Quantidade += quantidadeInicial;
                return true;
            }
        }

        public void VerificarEstoque()
        {

            foreach (Medicamento medicamento in estoque)
            {
                Console.WriteLine($"| {medicamento.Id}".PadRight(5) +
                                  $"| {medicamento.Nome}".PadRight(19) +
                                  $"| {medicamento.Descricao}".PadRight(30) +
                                  $"| {medicamento.Quantidade}".PadRight(7) +
                                  $"| {medicamento.Validade.ToShortDateString()}".PadRight(12) +
                                  " |");
            }
            Console.ReadKey();
        }

        public void AtualizarEstoque()
        {

            int Seletor = Program.ObterValor<int>("Selecione um ID: ");

            Medicamento Verificador = (Medicamento)estoque.FirstOrDefault(M => M.Id == Seletor);

            if (Verificador == null)
                Console.WriteLine("Nenhum medicamento encontrado!");
            else
            {
                SelecionarMedicamento(Verificador);
            }

            //        public Medicamento(int id, string nome, string descricao, int quantidade, datetime validade)
        }

        private void SelecionarMedicamento(Medicamento Verificador)
        {
            int opcao = Program.ObterValor<int>("Selecione o campo que deseja editar:\n1 - Nome\n2 - Descrição\n3 - Validade\n0 - Sair \nDigite: ");

            switch (opcao)
            {
                case 1:
                    string novoNome = Program.ObterValor<string>("Nome: ");

                    EditarNome(Verificador, novoNome);
                    break;
                case 2:

                    string novaDescricao = Program.ObterValor<string>("Descrição: ");

                    EditarDescricao(Verificador, novaDescricao);
                    break;
                case 3:

                    DateTime novaValidade = Program.ObterValor<DateTime>("Validade: ");

                    EditarValidade(Verificador, novaValidade);
                    break;
                case 0:
                    menu.MenuMedicamentos();
                    break;
            }
        }

        public bool EditarNome(Medicamento medicamentoEditado, string novoNome)
        {
            if (novoNome == null)
                return false;

            medicamentoEditado.Nome = novoNome;
            return true;
        }
        public bool EditarDescricao(Medicamento medicamentoEditado, string novaDescricao)
        {
            if (novaDescricao == null)
                return false;

            medicamentoEditado.Descricao = novaDescricao;
            return true;
        }
        public bool EditarValidade(Medicamento medicamentoEditado, DateTime novaValidade)
        {
            if (novaValidade == null)
                return false;

            medicamentoEditado.Validade = novaValidade;
            return true;
        }
        public void ExcluirMedicamento()
        {
            int Seletor = Program.ObterValor<int>("Digite um ID: ");

            Medicamento Verificador = (Medicamento)estoque.FirstOrDefault(M => M.Id == Seletor);

            if (Verificador == null)
                Console.WriteLine("Nenhum medicamento encontrado!");

            else
            {
                estoque.Remove(Verificador);
            }
        }

    }
}
