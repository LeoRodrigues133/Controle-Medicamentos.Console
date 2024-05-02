namespace ControleMedicamentos.ConsoleApp.ModuloBase
{
    public class Entidade
    {
        public static int idEntidade = 0;
        public static int idPaciente = 0;
        public static int idMedicamento = 0;
        public static int idRequisicao = 0;
        public int Id { get; }

            public Entidade()
            {
                Id = GerarNovoId();
            }

            public static int ProximoId()
            {
                return idEntidade++;
            }

            public static int ProximoIdPaciente()
            {
                return idPaciente++;
            }

            protected int GerarNovoId()
            {
                return ProximoId();
            }
        }
    }
