namespace ControleMedicamentos.ConsoleApp.ModuloBase
{
    public class Entidade
    {

        public int Id { get; set; }

        private int TotalRegistros
        {
            get
            {
                return Id++;
            }
        }
    }
}

