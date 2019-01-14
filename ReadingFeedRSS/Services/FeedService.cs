using HtmlAgilityPack;
using ReadingFeedRSS.Models;
using ReadingFeedRSS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace ReadingFeedRSS.Services
{
    public class FeedService : WebGenericService, IFeedService
    {
        public List<FeedModel> ObterFeeds(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            List<FeedModel> feeds = new List<FeedModel>();

            foreach (SyndicationItem item in feed.Items)
            {
                feeds.Add(new FeedModel() { Titulo = item.Title.Text, Sumario = item.Summary.Text, Url = item.Id });
            }

            return feeds;
        }

        public string PegarMateriaCompleta(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var article = doc.DocumentNode.Descendants("article");

            var stringObject = article.FirstOrDefault(s => s.OuterHtml.Contains("<div class=\"article-content\">")).InnerText;

            int indexOfSteam = stringObject.IndexOf("Gostou da matéria? Deixe sua nota!");
            if (indexOfSteam >= 0)
                stringObject = stringObject.Remove(indexOfSteam);

            stringObject = stringObject.Substring(stringObject.IndexOf("»  Viagem") + 9);

            return stringObject;
        }

        public override string PegarHTML(string url)
        {
            byte[] txtPageHTML = null;

            WebClient MyWebClient = new WebClient();

            if (url != "")
            {
                txtPageHTML = MyWebClient.DownloadData(url);
            }

            return Encoding.UTF8.GetString(txtPageHTML);
        }
    }
}
