using ReadingFeedRSS.Models;
using ReadingFeedRSS.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ReadingFeedRSS.Services
{
    public class PalavraService : IPalavraService
    {
        public List<PalavraModel> ContabilizarPalavras(List<string> palavras)
        {
            var lstPalavras = new List<PalavraModel>();

            foreach (var item in palavras.Distinct().ToList())
            {
                lstPalavras.Add(new PalavraModel() { Nome = item, Quantidade = palavras.Where(x => x == item).ToList().Count });
            }

            return lstPalavras;
        }
    }
}
