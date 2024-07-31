using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using System.Net;
using Trello_RestSharp.Consts;

namespace Trello_RestSharp.Tests.Update
{
    public class UpdateBoardTest : BaseTest
    {
        [Test]
        public void CheckUpdateBoard()
        {
            var updatedName = "Updated Name" + DateTime.Now.ToLongTimeString();
            var request = RequestWithAuth(CardsEndpoints.UpdateBoardUrl)
                .AddUrlSegment("id", UrlParamValues.BoardIdToUpdate)
                .AddJsonBody(new Dictionary<string, string> { { "name", updatedName } });
            var response = _client.Put(request);

            var responseContent = JToken.Parse(response.Content);

            ClassicAssert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            ClassicAssert.AreEqual(updatedName, responseContent.SelectToken("name").ToString());

            request = RequestWithAuth(CardsEndpoints.GetBoardUrl)
                .AddUrlSegment("id", UrlParamValues.BoardIdToUpdate);
            response = _client.Get(request);
            responseContent = JToken.Parse(response.Content);
            ClassicAssert.AreEqual(updatedName, responseContent.SelectToken("name").ToString());
        }
    }
}
