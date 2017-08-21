using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace ImdbCommunication.Tests
{
    public class ImdbApiSearchExplorationsTests
    {
        private readonly ITestOutputHelper output;

        public ImdbApiSearchExplorationsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        private string Execute(string query)
        {
            return new ImdbRawCommunication().Search(query);
        }

        [Fact]
        public void ReturnsResponse()
        {
            string results = Execute("Batman");
            Assert.NotEmpty(results);
        }

        [Fact]
        public void RetrunsJsonResponse()
        {
            string json = Execute("Batman");
            output.WriteLine(json);
            var ex = Record.Exception(() => JsonDeserializer.DeserializeJson<dynamic>(json));
            Assert.Null(ex);
        }

        [Fact]
        public void ReturnsBatmanReturnsAmongOtherResultsWhenSearchingForBatman()
        {
            string json = Execute("Batman");
            dynamic deserializedObject = JsonDeserializer.DeserializeJson<dynamic>(json);
            dynamic[] searchResults = deserializedObject["Search"];
            Assert.True(searchResults.Length > 1);
            dynamic batmanReturns = searchResults.SingleOrDefault(x => x["Title"] == "Batman Returns");
            Assert.NotNull(batmanReturns);
            Assert.Equal("Batman Returns", batmanReturns["Title"]);
            Assert.Equal("1992", batmanReturns["Year"]);
            Assert.Equal("tt0103776", batmanReturns["imdbID"]);
        }

        //[Fact]
        //public void Pass()
        //{
        //    Assert.Equal(4, Add(2, 2));
        //}

        //[Fact]
        //public void Fail()
        //{
        //    List<int> list = null;
        //    Assert.NotNull(list);
        //}

        //[Fact]
        //public void PassingTest()
        //{
        //    Assert.Equal(4, Add(2, 2));
        //}

        //[Fact]
        //public void FailingTest()
        //{
        //    Assert.Equal(5, Add(2, 2));
        //}

        //int Add(int x, int y)
        //{
        //    return x + y;
        //}

        //[Theory]
        //[InlineData(3)]
        //[InlineData(5)]
        //[InlineData(6)]
        //public void MyFirstTheory(int value)
        //{
        //    Assert.True(IsOdd(value));
        //}

        //bool IsOdd(int value)
        //{
        //    return value % 2 == 1;
        //}
    }
}
