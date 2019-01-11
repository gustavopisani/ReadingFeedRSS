using ReadingFeedRSS.Services;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ReadingFeedRSS
{
    public class Program
    {
        static void Main(string[] args)
        {
            FeedService feedService = new FeedService();
            RegrasService regrasService = new RegrasService();
            PalavraService palavraService = new PalavraService();
            ImpressaoService impressaoService = new ImpressaoService();

            string[] artigosDefinidosIndefinidosPreposicoes = new string[] { "a", "ante", "após", "até", "com", "contra", "de", "desde", "em", "entre", "para", "perante", "por", "sem", "sob", "sobre", "trás", "a", "à", "da", "na", "pela", "o", "ao", "do", "no", "pelo", "as", "às", "das", "nas", "pelas", "os", "aos", "dos", "nos", "pelos", "um", "uma", "uns", "umas", "dum", "duma", "duns", "dumas", "num", "numa", "nuns", "numas", "que", "e", "é" };

            var feeds = feedService.ObterFeeds("http://www.minutoseguros.com.br/blog/feed/");

            var result = new List<string>();

            var sumariao = string.Empty;

            foreach (var feed in feeds)
            {

                sumariao = sumariao + " " + feed.Sumario;

                var sumarioResult = string.Empty;

                sumarioResult = regrasService.RemoverElementosHTML(feed.Sumario);
                sumarioResult = regrasService.RemoverPontuacoes(sumarioResult);

                result = regrasService.RemoverPalavras(artigosDefinidosIndefinidosPreposicoes, sumarioResult.Split(' ').ToList());

                var palavrasContabilizadas = palavraService.ContabilizarPalavras(result);

                impressaoService.ImprimirResultadoAnalisePorFeed(palavrasContabilizadas, feed);
            }
            
            sumariao = regrasService.RemoverElementosHTML(sumariao);
            sumariao = regrasService.RemoverPontuacoes(sumariao);

            result = regrasService.RemoverPalavras(artigosDefinidosIndefinidosPreposicoes, sumariao.Split(' ').ToList());

            var palavras = palavraService.ContabilizarPalavras(result);

            impressaoService.ImprimirResultadoAnalisePorFeed(palavras);

            Console.ReadKey();
        }

        

    }
}
