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
        public void Excluir(int Seletor)
        {

            Paciente Verificador = (Paciente)rPessoas.RegistroPessoas.FirstOrDefault(M => M.Id == Seletor);

            if (Verificador == null)
                Console.WriteLine("Nenhum paciente encontrado!");

            else
            {
                rPessoas.RegistroPessoas.Remove(Verificador);
            }
        }


    }
}
