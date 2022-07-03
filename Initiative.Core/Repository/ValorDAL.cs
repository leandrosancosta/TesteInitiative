namespace Initiative.Core
{
    public class ValorDAL : IValorDAL
    {
        private Context _context = new Context();
        private IQueryable<Valor>? GetValues()
        {
            try
            {
                var values = _context.Valores;
                return values;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        private bool SetValue(double value, string decomposed)
        {
            try
            {
                var val = _context.Valores.Where(v => v.Valores == value).FirstOrDefault();
                if (val == null)
                {
                    return false;
                }
                val.Decomposto = decomposed;
                _context.Update(val);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<double> GetValores()
        {
            var value = GetValues();
            if (value == null)
                return new List<double>();
            var valores = value.Select(v => v.Valores).ToList();
            return valores == null ? new List<double>() : valores;
        }
        public List<Valor> GetTabela()
        {
            var value = GetValues();
            if (value == null)
                return new List<Valor>();
            var valores = value.ToList();
            return valores == null ? new List<Valor>() : valores;
        }
        public bool SaveDecompost(double valor, string decomposto)
        {
            return SetValue(valor, decomposto);
        }

    }
}
