using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initiative.Core
{
    public sealed class Moeda
    {
        public int Id { get; set; }
        public string? Descritivo { get; set; }
        public double Valor { get; set; }
        public string? Formato { get; set; }
    }
}
