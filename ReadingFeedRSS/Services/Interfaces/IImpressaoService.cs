using ReadingFeedRSS.Models;
using System.Collections.Generic;

namespace ReadingFeedRSS.Services.Interfaces
{
    public interface IImpressaoService
    {
        void ImprimirResultadoAnalisePorFeed(FeedModel model, List<PalavraModel> palavras);
    }
}
