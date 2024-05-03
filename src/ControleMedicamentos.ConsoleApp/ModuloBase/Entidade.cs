namespace ControleMedicamentos.ConsoleApp.ModuloBase
{
    public class Entidade
    {
        public int Id { get; set; }
        public int idGeral = 1;

        public Entidade()
        {
            Id = GerarNovoId();
        }

        protected int GerarNovoId()
        {
            return idGeral++;
        }
    }
}
