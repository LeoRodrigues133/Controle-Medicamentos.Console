using Controle_de_Medicamentos_2024_ConsoleApp.ModuloInterface;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;
using Controle_de_Medicamentos_2024_ConsoleApp;
using Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa;

namespace ControleMedicamentos.ConsoleApp.ModuloPessoa
{
    public class DominioPessoas
    {
        public InterfacePessoas uiPessoas;
        public RepositorioPessoas rPessoas;
        public Menu menu;

        public bool VerificarCpf(string cpf, RepositorioPessoas rPessoas)
        {

            Paciente verificador = rPessoas.RegistroPessoas.FirstOrDefault(p => p.Cpf == cpf);

            if (verificador == null)
                return true;

            Console.WriteLine("Esta Pessoa já esta cadastrada!");
            Console.ReadKey();
            return false;
        }

        public bool EditarNome(Paciente pacienteEditado, string novoNome)
        {
            if (novoNome == null)
                return false;

            pacienteEditado.Nome = novoNome;
            return true;
        }

        public bool EditarEndereco(Paciente pacienteEditado, string novoEndereco)
        {
            if (novoEndereco == null)
                return false;

            pacienteEditado.Endereco = novoEndereco;
            return true;
        }

        public bool EditarDDN(Paciente pacienteEditado, DateTime novaDDN)
        {
            if (novaDDN == null)
                return false;

            pacienteEditado.DataDeNascimento = novaDDN;
            return true;
        }
        


        public void Cabecalho()
        {
            Console.WriteLine("| ID".PadRight(5) +
                               "| Nome".PadRight(20) +
                               "| CPF".PadRight(17) +
                               "| Endereço".PadRight(17) +
                               "| Registro SUS".PadRight(12) +
                               "| Data de Nascimento".PadRight(20) +
                               " |");
            Rodape();
        }
        public void Rodape()
        {
            Console.WriteLine(new string('-', 95));

        }
    }
}
