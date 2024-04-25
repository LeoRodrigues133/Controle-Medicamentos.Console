namespace ControleMedicamentos.ConsoleApp.ModuloBase
{
    public class Entidade
    {

        public int Id { get; set; }



        public Entidade(int id)
        {
            this.Id = id;
           
        }


        private int TotalRegistros
        {
            get
            {
                return Id++;
            }
        }
    }
}

