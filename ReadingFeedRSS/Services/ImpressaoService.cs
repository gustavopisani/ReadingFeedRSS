using ReadingFeedRSS.Models;
using ReadingFeedRSS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadingFeedRSS.Services
{
    public class ImpressaoService : IImpressaoService
    {
        public void ImprimirResultadoAnalisePorFeed(FeedModel model, List<PalavraModel> palavras)
        {
            var i = 1;

            Console.WriteLine("Realizando análise para o tópico: " + model.Titulo);
            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in palavras.OrderByDescending(a => a.Quantidade))
            {
                Console.WriteLine(i++ + "ª - " + item.Nome + ", foi encontrada " + item.Quantidade + "vezes");
            }

            Console.WriteLine();
            Console.WriteLine("Sendo as 10 primeiras listadas as principais palavras abordadas no tópico analisado.");

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
