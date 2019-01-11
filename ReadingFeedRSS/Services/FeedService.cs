using ReadingFeedRSS.Models;
using ReadingFeedRSS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace ReadingFeedRSS.Services
{
    public class FeedService : IFeedService
    {
        public List<FeedModel> ObterFeeds(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            List<FeedModel> feeds = new List<FeedModel>();

            foreach (SyndicationItem item in feed.Items)
            {
                feeds.Add(new FeedModel() { Titulo = item.Title.Text, Sumario = item.Summary.Text });
            }

            return feeds;
        }
    }
}
