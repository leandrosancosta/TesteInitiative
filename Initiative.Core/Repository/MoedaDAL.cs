using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initiative.Core
{
    public class MoedaDAL : IMoedaDAL
    {
        private Context _context = new Context();
        private IQueryable<Moeda>? GetValues()
        {
            try
            {
                var values = _context.Moeda;
                return values;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<double> GetMoedaValores()
        {
            var value = GetValues();
            if (value == null)
                return new List<double>();
            var coins = value.Where(c => c.Formato == "Moeda").Select(s => s.Valor).ToList();
            return coins == null ? new List<double>() : coins;
        }
        public List<double> GetNotasValores()
        {
            var value = GetValues();
            if (value == null)
                return new List<double>();
            var notes = value.Where(c => c.Formato == "Nota").Select(s => s.Valor).ToList();
            return notes == null ? new List<double>() : notes;
        }
        public List<Moeda> GetMoedas()
        {
            var value = GetValues();
            return value == null ? new List<Moeda>() : value.ToList();
        }
    }
}
