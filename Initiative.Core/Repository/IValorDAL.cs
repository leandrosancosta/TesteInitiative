namespace Initiative.Core
{
    public interface IValorDAL
    {
        public List<double> GetValores();
        public List<Valor> GetTabela();
        public bool SaveDecompost(double valor, string decomposto);
    }
}
