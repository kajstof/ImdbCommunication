using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImdbCommunication.Test
{
    public class ImdbDataParserDetailsTests
    {
        private ImdbDataParser _parser;

        public ImdbDataParserDetailsTests()
        {
            _parser = new ImdbDataParser();
        }

        Movie Execute(string json)
        {
            return _parser.ParseDetails(json);
        }

        [Fact]
        public void ParsesMovieTitle()
        {
            Movie batmanReturns = Execute(EmbeddedResources.GetResource("details.json"));
            Assert.Equal("Batman Returns", batmanReturns.Title);
        }

        [Fact]
        public void ParsesMovieYear()
        {
            Movie batmanReturns = Execute(EmbeddedResources.GetResource("details.json"));
            Assert.Equal(1992, batmanReturns.Year);
        }

        [Fact]
        public void ParsesMovieDirector()
        {
            Movie batmanReturns = Execute(EmbeddedResources.GetResource("details.json"));
            Assert.Equal("Tim Burton", batmanReturns.Director);
        }
    }
}
