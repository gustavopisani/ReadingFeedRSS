using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingFeedRSS.Services
{
    public abstract class WebGenericService
    {
        public abstract string PegarHTML(string url);
    }
}
