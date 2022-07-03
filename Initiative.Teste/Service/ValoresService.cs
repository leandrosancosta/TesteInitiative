using Initiative.Core;

namespace Initiative.Teste.Service
{
    public class ValoresService
    {
        private static IMoedaDAL moedaDAL = new MoedaDAL();
        private static IValorDAL valorDAL = new ValorDAL();
        List<double> notas;
        List<double> moedas;

        public ValoresService()
        {
            notas = moedaDAL.GetNotasValores();
            moedas = moedaDAL.GetMoedaValores();
            notas.Reverse();
            moedas.Reverse();
        }

        public string[]? Decomposicao()
        {
            Console.WriteLine("Iniciando");
            var valores = valorDAL.GetValores().ToList();
            string tabela = string.Empty;
            foreach (var valor in valores)
            {
                var roundValor = Math.Round(valor, 2);
                string decompose = string.Empty;
                foreach (var nota in notas)
                {
                    if (nota <= roundValor)
                    {
                        int qtd = (int)(roundValor / nota);
                        roundValor -= qtd * nota;
                        string plural = qtd == 1 ? "" : "s";
                        decompose += $"{qtd} nota{plural} de {nota};";
                    }
                }
                if (roundValor == 0)
                {
                    Console.WriteLine(decompose);
                    valorDAL.SaveDecompost(valor, decompose);
                    tabela += decompose + '\n';
                    continue;
                }
                roundValor = Math.Round(roundValor, 2);
                string decomposeCoins = string.Empty;
                foreach (var moeda in moedas)
                {
                    if (moeda < roundValor)
                    {
                        var r = (int)(roundValor * 100);
                        var m = (int)(moeda * 100);
                        int qtd = r / m;
                        roundValor -= qtd * m;
                        string plural = qtd == 1 ? "" : "s";
                        decomposeCoins += $"{qtd} moeda{plural} de {moeda.ToString("0.00")};";
                    }
                }
                var arrayDecomposeCoins = decomposeCoins.Split(';');
                arrayDecomposeCoins.Reverse();
                foreach (var a in arrayDecomposeCoins)
                {
                    if (!string.IsNullOrEmpty(a))
                        decompose += $"{a};";
                }
                Console.WriteLine(decompose);
                valorDAL.SaveDecompost(valor, decompose);
                tabela += decompose + '\n';
            }
            return tabela.Split('\n');
        }
        public List<Valor> GetTabela()
        {
            return valorDAL.GetTabela();
        }

    }
}
