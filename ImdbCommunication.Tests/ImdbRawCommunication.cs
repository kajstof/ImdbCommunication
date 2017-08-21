using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ImdbCommunication.Tests
{
    public class ImdbRawCommunication
    {
        public string Search(string query)
        {
            return getHttp("s=" + query);
        }

        public string Details(string imdbId)
        {
            return getHttp("i=" + imdbId);
        }

        private static string getHttp(string queryString)
        {
            string url = "http://www.omdbapi.com?" + queryString;
            return new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        //private static string getHttp(string queryString)
        //{
        //    string url = "http://www.omdbapi.com?" + queryString;
        //    return new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        //}
    }
}
