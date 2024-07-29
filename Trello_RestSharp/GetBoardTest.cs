using NUnit.Framework;
using RestSharp;
using System.Net;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Legacy;
using Trello_RestSharp;

namespace BoardTest
{
    public class GetBoardTest : BaseTest
    {    
        [Test]
        public void CheckGetBoards()
        {
            var request = RequestWithAuth("/1/members/{member}/boards")
                .AddUrlSegment("member", "ajeigbekehindetimothy");
            var response = _client.Get(request);
            ClassicAssert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void CheckGetBoard()
        {
            var request = RequestWithAuth("/1/boards/{id}")
                .AddUrlSegment("id", "5abbe4b7ddc1b351ef961414");
            var response = _client.Get(request);
            ClassicAssert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            ClassicAssert.AreEqual("Trello Platform Changelog", JToken.Parse(response.Content).SelectToken("name").ToString());
        }
    }
}