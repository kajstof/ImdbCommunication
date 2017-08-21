using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ImdbCommunication.Tests
{
    public class ImdbDataParser
    {
        public Movie ParseDetails(string json)
        {
            return JsonDeserializer.DeserializeJson<Movie>(json);
        }

        public MovieSearch ParseSearch(string json)
        {
            return JsonDeserializer.DeserializeJson<MovieSearch>(json);
        }
    }
}
