using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using Trello_RestSharp.Tests;

namespace Trello_RestSharp.Tests.Get
{
    public class GetCardsTest : BaseTest
    {

        [Test]
        public void CheckGetCards()
        {
            var request = RequestWithAuth("/1/card/{list_id}/list")
                .AddQueryParameter("fields", "id,name")
                .AddUrlSegment("list_id", "60d84769c4ce7a09f9140221");
            var response = _client.Get(request);
            ClassicAssert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_cards.json"));
            ClassicAssert.True(responseContent.IsValid(jsonSchema));
        }

        [Test]
        public void CheckGetCard()
        {
            var request = RequestWithAuth("/1/cards/{id}")
                //.AddQueryParameter("fields", "id,name")
                .AddUrlSegment("id", "5abbe4b7ddc1b351ef961414");
            var response = _client.Get(request);
            ClassicAssert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_card.json"));
            ClassicAssert.True(responseContent.IsValid(jsonSchema));
            ClassicAssert.AreEqual("Test card", responseContent.SelectToken("name").ToString());
        }
    }
}