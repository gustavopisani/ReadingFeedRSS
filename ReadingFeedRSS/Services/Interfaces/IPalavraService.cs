using ReadingFeedRSS.Models;
using System.Collections.Generic;

namespace ReadingFeedRSS.Services.Interfaces
{
    public interface IPalavraService
    {
        List<PalavraModel> ContabilizarPalavras(List<string> palavras);
    }
}
