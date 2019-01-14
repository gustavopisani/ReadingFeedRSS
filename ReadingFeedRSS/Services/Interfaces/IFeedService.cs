using ReadingFeedRSS.Models;
using System.Collections.Generic;

namespace ReadingFeedRSS.Services.Interfaces
{
    public interface IFeedService
    {
        List<FeedModel> ObterFeeds(string url);
        string PegarMateriaCompleta(string html);
    }
}
