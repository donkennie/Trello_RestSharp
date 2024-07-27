using NUnit.Framework;
using RestSharp;
using System.Net;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Legacy;

namespace BoardTest
{
    public class GetBoardTest
    {
        private static IRestClient _client;

        [OneTimeSetUp]
        public static void InitializeRestClient() =>
            _client = new RestClient(baseUrl: "https://api.trello.com");

        private RestRequest RequestWithAuth(string resource) =>
           new RestRequest(resource)
               .AddQueryParameter(name: "key", value: "3d163ab039bdfde417d8694a031fcdb0")
               .AddQueryParameter(name: "token", value: "ATTAb8f33b16f11bdddbaeec4e7d0ef356624dfbc5a514030064601ee9bafc6a324226CF6654");

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