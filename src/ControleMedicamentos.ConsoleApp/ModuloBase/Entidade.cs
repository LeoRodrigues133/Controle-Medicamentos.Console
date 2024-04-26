namespace ControleMedicamentos.ConsoleApp.ModuloBase
{
    public class Entidade
    {
        private static int contador = 1;
        public int Id { get; } 

        public Entidade()
        {
            Id = GerarNovoId();
        }   

        private int GerarNovoId()
        {
            return contador++;
        }
    }
}
