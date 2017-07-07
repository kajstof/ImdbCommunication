using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImdbCommunication.Test
{
    public class ImdbDataParserSearchTests
    {
        private ImdbDataParser _parser;

        public ImdbDataParserSearchTests()
        {
            _parser = new ImdbDataParser();
        }

        MovieSearch Execute(string json)
        {
            return _parser.ParseSearch(json);
        }

        [Fact]
        public void ParsesMovieTitle()
        {
            MovieSearch batmanReturns = Execute(EmbeddedResources.GetResource("search.json"));
            Assert.Equal("Batman Returns", batmanReturns.Title);
        }

        [Fact]
        public void ParsesMovieDirector()
        {
            MovieSearch batmanReturns = Execute(EmbeddedResources.GetResource("search.json"));
            Assert.Equal("tt0103776", batmanReturns.ImdbId);
        }
    }
}
