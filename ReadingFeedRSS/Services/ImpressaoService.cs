using ReadingFeedRSS.Models;
using ReadingFeedRSS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadingFeedRSS.Services
{
    public class ImpressaoService : IImpressaoService
    {
        public void ImprimirResultadoAnalisePorFeed(List<PalavraModel> palavras, FeedModel model = null)
        {
            var i = 1;

            if (model != null)
            {
                Console.WriteLine("Realizando análise para o tópico: " + model.Titulo);
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Realizando análise para todos os tópicos");
                Console.WriteLine();
                Console.WriteLine();
            }

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
