using HtmlAgilityPack;
using Newtonsoft.Json;
using ReadingFeedRSS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;


namespace ReadingFeedRSS.Services
{
    public class RegrasService : IRegrasService
    {
        public List<string> RemoverPalavras(string[] palavrasProibidas, List<string> palavras)
        {
            List<string> palavrasOk = new List<string>();

            foreach (var palavra in palavras)
            {
                if (!palavrasProibidas.Contains(palavra.ToLower()))
                {
                    palavrasOk.Add(palavra.Trim());
                }
            }

            return palavrasOk;
        }
        
        public string RemoverElementosHTML(string texto)
        {
            return Regex.Replace(texto, "<.*?>", String.Empty).Replace("\n", String.Empty);
        }

        public string RemoverPontuacoes(string texto)
        {
            return texto.Replace(".", String.Empty).Replace(",", String.Empty).Replace("?", String.Empty);
        }
    }
}
