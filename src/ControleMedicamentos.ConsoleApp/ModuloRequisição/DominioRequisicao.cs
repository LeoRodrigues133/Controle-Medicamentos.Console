using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPessoa;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;
using System.Globalization;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisição
{
    public class DominioRequisicao
    {
        public RepositorioRequisicao rRequisicao;
        public RepositorioPessoas rPessoas;
        public RepositorioMedicamentos rMedicamentos;
        public Paciente Paciente;
        public Medicamento medicamento;
        public InterfaceRequisicao uiRequisicao;
        public Menu menu;
        public bool VerificarNRSUS(int NRSUS, RepositorioPessoas rPessoas, DominioRequisicao dominio)
        {

            Paciente verificador = rPessoas.RegistroPessoas.FirstOrDefault(p => p.RegistroSUS == NRSUS);

            if (verificador == null)
                return true;

            Console.WriteLine("Esta carteira do SUS já esta cadastrada!");
            Console.ReadKey();
            return false;
        }
        public bool BuscarMedicamento(string nomeMedicamento, RepositorioMedicamentos rMedicamentos)
        {
            Medicamento medicamentoRequisitado = rMedicamentos.estoque.FirstOrDefault(m => m.Nome == nomeMedicamento);
            if (medicamentoRequisitado == null)
            {
                Console.WriteLine("Nenhum medicamento encontrado.");
                return false;
            }
            else
                return true;
        }
        public bool VerificarNRSUS(int verificarNRSUS, RepositorioPessoas rPessoas)
        {

            Paciente Verificador = rPessoas.RegistroPessoas.FirstOrDefault(RegistroSUS => RegistroSUS.RegistroSUS == verificarNRSUS);

            if (Verificador == null)
            {
                Console.WriteLine("Paciente não encontrado!");
                return false;
            }

            Console.WriteLine("NRSUS encontrado!");

            return true;
        }
        public bool BuscarPaciente(string nomePaciente, RepositorioPessoas rPessoas)
        {
            Paciente requisitante = rPessoas.RegistroPessoas.FirstOrDefault(p => p.Nome == nomePaciente);
            if (requisitante == null)
            {
                Console.WriteLine("Paciente não encontrado");
                return false;
            }
            else
                return true;
        }// não utilizado. Mas util para mais tarde;
        public void VerPacientes(RepositorioPessoas rPaciente)
        {
            foreach (Paciente paciente in rPaciente.RegistroPessoas)
            {
                Console.WriteLine($"| {paciente.Id}".PadRight(5) +
                                           $"| {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(paciente.Nome)}".PadRight(10) +
                                           $"| {paciente.Cpf}".PadRight(17) +
                                           $"| {paciente.RegistroSUS.ToString().PadRight(7)}" +
                                            " |");
            }
        }
        public void VerMedicamentos(RepositorioMedicamentos rMedicamentos, DominioMedicamentos dominio)
        {
            foreach (Medicamento medicamento in rMedicamentos.estoque)
            {
                {
                    Console.Write($"| {medicamento.Id}".PadRight(5) +
                                          $"| {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(medicamento.Nome)}".PadRight(19) + "|");
                    dominio.VerificarQuantidadeEstoque(medicamento);
                    Console.WriteLine("|");
                }
            }
        }
        public bool AceitarRequisicao(int IdBuscador, RepositorioPessoas registroPessoas, RepositorioMedicamentos estoqueMedicamentos, Paciente paciente, DominioRequisicao dRequisicao, RepositorioRequisicao rRequisicao)
        {

            Requisicao verificador = rRequisicao.registroRequisicao.FirstOrDefault(r => r.Id == IdBuscador);

            if (verificador == null)
            {
                Console.WriteLine("Nenhuma requisição encontada!");
                return false;
            }
            Medicamento medicamento = estoqueMedicamentos.estoque.FirstOrDefault(m => m.Nome == verificador.medicamento);

            if (ObterQuantidadeSolicitada(medicamento, verificador, verificador.retirada) == 0)
            {
                Console.WriteLine("Quantidade solicitada não disponível no estoque.");
                return false;
            }
            else
            {
                rRequisicao.registroRequisicao.Remove(verificador);
                return true;
            }


        }

        public int ObterQuantidadeSolicitada(Medicamento medicamento, Requisicao requisicao, int quantidade)
        {

            if (quantidade > medicamento.Quantidade)
            {
                return 0;
            }
            else
                medicamento.Quantidade -= quantidade;

            return quantidade;
        }
        public void Cabecalho()
        {
            Console.WriteLine(" ID".PadRight(5) +
                               "| Nome".PadRight(19) +
                               "| Registro SUS".PadRight(12) +
                               "| Medicamento".PadRight(20) +
                               "| Qtd".PadRight(11) + "|");
            Rodape();
        }
        public void Rodape()
        {
            Console.WriteLine(new string('-', 70));

        }

    }
}

