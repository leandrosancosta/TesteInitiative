using Xunit;
using System.Linq;
namespace Initiative.UTest
{
    public class UnitTest
    {
        [Fact]
        public void TryConnectDB()
        {
            bool testPass = false;
            try
            {
                using (Context _context = new Context())
                {
                    var m = _context.Moeda.ToList();
                    var v = _context.Valores.ToList();

                }
                testPass = true;
            }
            catch
            {

            }
            Assert.True(testPass);
        }

        [Fact]
        public void DecomposeByDivision()
        {
            float num = 2543.21F;
            int[] notas = new int[] { 200, 100, 50, 20, 10, 5, 2 };
            int[] moedas = new int[] { 100, 50, 25, 10, 5, 1 };
            int[,] dec = new int[7, 2];
            int[,] decM = new int[6, 2];
            int value = 0;
            int j = 0;
            int k = 0;
            string decomposto = string.Empty;
            for (int i = 0; i < notas.Length; i++)
            {
                int v = notas[i];
                if (v < num)
                {
                    value = (int)num / v;
                    num -= value * v;
                    dec[j, 0] = notas[i];
                    dec[j, 1] = value;
                    j++;
                    decomposto += $"{value} nota(s) de {notas[i]};";
                }
                if ((int)num == 0)
                {
                    i = notas.Length;
                }
            }
            num *= 100;
            int num2 = int.Parse(num.ToString("0"));
            for (int i = 0; i < moedas.Length; i++)
            {
                int v = moedas[i];
                if (v < num2)
                {
                    value = num2 / v;
                    num2 -= value * v;
                    decM[k, 0] = moedas[i];
                    decM[k, 1] = value;
                    k++;
                    //double f = ((double)v / 100);
                    int is1r = v == 100 ? 1 : v;

                    decomposto += $"{value} moeda(s) de { is1r };";
                }
                if ((int)num2 == 0)
                {
                    i = moedas.Length;
                }
            }
            Assert.True(decomposto.Equals("12 nota(s) de 200;1 nota(s) de 100;2 nota(s) de 20;1 nota(s) de 2;1 moeda(s) de 1;2 moeda(s) de 10;"));
        }
    }
}