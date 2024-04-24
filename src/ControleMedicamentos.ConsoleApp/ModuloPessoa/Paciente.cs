using Controle_de_Medicamentos_2024_ConsoleApp.ModuloMedicamento;

namespace Controle_de_Medicamentos_2024_ConsoleApp.ModuloPessoa
{
    public class Paciente
    {
        public Requisicao requisicaoMedicamentos;
        public Pessoa pessoa;
        public int registroSUS;
        public string cpf, nome, endereco, requisicao;

        public Paciente(int registroSUS, string requisicao, string nome, string cpf, string endereco, Pessoa pessoa)
        {
            this.registroSUS = registroSUS;
            this.requisicao = requisicaoMedicamentos.GerarRequisicao();
            this.nome = pessoa.nome;
            this.cpf = pessoa.cpf;
            this.endereco = pessoa.endereco;
            this.pessoa = pessoa;
        }
    }
}