using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp;
using System.Globalization;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class DominioMedicamentos
    {
        public Medicamento medicamento;
        public Menu menu;
        public RepositorioMedicamentos rMedicamentos;

        #region Métodos do Create
        public bool VerificarMedicamento(string nome, int quantidade, RepositorioMedicamentos rMedicamentos, Medicamento medicamento)
        {
            Medicamento verificador = rMedicamentos.estoque.FirstOrDefault(m => m.Nome == nome);

            if (verificador == null)
            {
                Console.WriteLine("\nNovo medicamento registrado com sucesso!");
                Console.ReadKey();
                Console.Clear();
                return true;
            }
            else
            {
                VerificarQuantidade(quantidade, verificador, rMedicamentos);
            }

            return false;
        } //Adiciona quantidade se já existir
        #endregion

        public void AtualizarCampo(Medicamento Verificador)
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

        #region Métodos do Update

        private bool EditarNome(Medicamento medicamentoEditado, string novoNome)
        {
            if (novoNome == null)
                return false;

            medicamentoEditado.Nome = novoNome;
            return true;
        }
        private bool EditarDescricao(Medicamento medicamentoEditado, string novaDescricao)
        {
            if (novaDescricao == null)
                return false;

            medicamentoEditado.Descricao = novaDescricao;
            return true;
        }
        private bool EditarValidade(Medicamento medicamentoEditado, DateTime novaValidade)
        {
            if (novaValidade == null)
                return false;

            medicamentoEditado.Validade = novaValidade;
            return true;
        }

        #endregion

        #region validação de quantidade

        public int VerificarQuantidade(int incrementarQuantidade, Medicamento medicamento, RepositorioMedicamentos repositorioMedicamentos)
        {
            medicamento.Quantidade += incrementarQuantidade;
            Console.WriteLine("\nQuantidade atualizada com sucesso!");
            Console.ReadKey();
            Console.Clear();
            return medicamento.Quantidade;
        }

        public Medicamento VerificarQuantidadeEstoque(Medicamento medicamento)
        {
            if (medicamento.Quantidade <= 20)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(medicamento.Quantidade.ToString().PadRight(11));
                Console.ResetColor();
            }
            else
                Console.Write(medicamento.Quantidade.ToString().PadRight(11));
            return medicamento;

        }

        public bool RetirarMedicamento(int Solicitacao, string teste, Medicamento verificador, RepositorioMedicamentos rMedicamentos)
        {
            verificador = rMedicamentos.estoque.FirstOrDefault(p => p.Nome == teste);

            if (verificador.Quantidade >= Solicitacao)
            {
                verificador.Quantidade -= Solicitacao;
                return true;
            }
            else
            {
                Console.WriteLine("Quantidade solicitada excede o estoque!");
                return false;
            }
        }
        #endregion

        public void Cabecalho()
        {
            Console.WriteLine("| ID".PadRight(5) +
                               "| Nome".PadRight(19) +
                               "| Descrição".PadRight(56) +
                               "| Quantidade".PadRight(12) +
                               "| Validade".PadRight(11) +
                               " |");
            Rodape();
        }
        public void Rodape()
        {
            Console.WriteLine(new string('-', 105));

        }
    }
}