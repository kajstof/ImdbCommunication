using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace ImdbCommunication.Tests
{
    public class ImdbApiDetailsExplorationsTests
    {
        private readonly ITestOutputHelper output;

        public ImdbApiDetailsExplorationsTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        private string Execute(string imdbId)
        {
            return new ImdbRawCommunication().Details(imdbId);
        }

        [Fact]
        public void RetrunsJsonResponse()
        {
            string json = Execute("tt0104776");
            output.WriteLine(json);
            var ex = Record.Exception(() => JsonDeserializer.DeserializeJson<dynamic>(json));
            Assert.Null(ex);
        }

        [Fact]
        public void ReturnsDetailsAboutBatmanReturnsWhenGivenItsId()
        {
            string json = Execute("tt0104776");
            dynamic batmanReturnsDetails = JsonDeserializer.DeserializeJson<dynamic>(json);
            Assert.Equal("Batman Returns", batmanReturnsDetails["Title"]);
            Assert.Equal("1992", batmanReturnsDetails["Year"]);
            Assert.Equal("Tim Burton", batmanReturnsDetails["Director"]);
            Assert.Equal("tt0103776", batmanReturnsDetails["imdbId"]);
            Assert.NotNull(batmanReturnsDetails["imdbRating"]);
        }
    }
}
