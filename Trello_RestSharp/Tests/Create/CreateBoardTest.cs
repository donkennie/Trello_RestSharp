using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using System.Net;
using Trello_RestSharp.Consts;

namespace Trello_RestSharp.Tests.Create
{
    public class CreateBoardTest : BaseTest
    {
        private string _createdCardId;

        [Test]
        public void CheckCreateCard()
        {
            var cardName = "New Card" + DateTime.Now.ToLongTimeString();

            var request = RequestWithAuth(CardsEndpoints.CreateBoardUrl)
                .AddJsonBody(new Dictionary<string, string>
                {
                    {"name", cardName},
                    {"idList", UrlParamValues.ExistingBoardId}
                });
            var response = _client.Post(request);

            var responseContent = JToken.Parse(response.Content);

            _createdCardId = responseContent.SelectToken("id").ToString();

            ClassicAssert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            ClassicAssert.AreEqual(cardName, responseContent.SelectToken("name").ToString());

            request = RequestWithAuth(CardsEndpoints.GetAllBoardsUrl)
                .AddUrlSegment("list_id", UrlParamValues.ExistingBoardId);
            response = _client.Get(request);
            responseContent = JToken.Parse(response.Content);
            ClassicAssert.True(responseContent.Children().Select(token => token.SelectToken("name").ToString()).Contains(cardName));
        }


        [TearDown]
        public void DeleteCreatedBoard()
        {
            var request = RequestWithAuth(CardsEndpoints.DeleteBoardUrl)
                .AddUrlSegment("id", _createdCardId);
            var response = _client.Delete(request);
            ClassicAssert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
