namespace ControleMedicamentos.ConsoleApp.ModuloBase
{
    public class Entidade
    {
        public static int contador = 0;
        public int Id { get; }

        public Entidade()
        {
            Id = GerarNovoId();
        }

        protected int GerarNovoId()
        {
            return contador++;
        }
    }
}
