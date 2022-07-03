namespace Initiative.Core
{
    public interface IMoedaDAL
    {
        public List<double> GetNotasValores();
        public List<double> GetMoedaValores();
        public List<Moeda> GetMoedas();
    }
}
