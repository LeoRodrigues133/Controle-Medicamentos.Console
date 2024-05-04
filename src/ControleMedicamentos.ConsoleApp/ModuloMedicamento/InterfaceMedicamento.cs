using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloBase;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class InterfaceMedicamentos
    {
        public DominioMedicamentos dMedicamentos;
        public RepositorioMedicamentos rMedicamentos;
        public Medicamento Medicamento;
        public Menu menu;
        public Entidade entidade;

        public InterfaceMedicamentos(RepositorioMedicamentos rMedicamentos)
        {
            this.rMedicamentos = rMedicamentos;
        }
        public void MenuAdicionarMedicamentos(DominioMedicamentos dominio, Medicamento id, RepositorioMedicamentos rMedicamentos)
        {

            Console.Clear();
            Console.WriteLine("Cadastro de medicamento");

            string nome = Program.ObterValor<string>("Digite o nome do medicamento:\n").ToLower();
            string descricao = Program.ObterValor<string>("Descrição do medicamento:\n");
            int quantidade = Program.ObterValor<int>("Quantidade de medicamentos adicionados:\n");
            DateTime validade = Program.ObterValor<DateTime>("Digite a validade do medicamento (dd/mm/yyyy):\n");

            if (Medicamento.VerificarValidade(validade))
                if (dominio.VerificarMedicamento(nome, quantidade, rMedicamentos, Medicamento))
                {
                    Medicamento novoMedicamento = new Medicamento(nome, descricao, quantidade, validade);
                    rMedicamentos.Adicionar(novoMedicamento, rMedicamentos);
                }
        }


        public void MenuAtualizarMedicamento(int Seletor, DominioMedicamentos dMedicamentos)
        {
            rMedicamentos.MostrarTodoEstoque(rMedicamentos, dMedicamentos);

            rMedicamentos.AtualizarMedicamento(Seletor, dMedicamentos, rMedicamentos);
        }


    }
}

