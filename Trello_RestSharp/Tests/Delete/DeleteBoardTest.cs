using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Trello_RestSharp.Consts;

namespace Trello_RestSharp.Tests.Delete
{
    public class DeleteBoardTest : BaseTest
    {
        private string _createdBoardId;

        [SetUp]
        public void CreateBoard()
        {
            var request = RequestWithAuth(CardsEndpoints.CreateBoardUrl)
                .AddJsonBody(new Dictionary<string, string> { { "name", "New Board" } });
            var response = _client.Post(request);
            _createdBoardId = JToken.Parse(response.Content).SelectToken("id").ToString();
        }

        [Test]
        public void CheckDeleteBoard()
        {
            var request = RequestWithAuth(CardsEndpoints.DeleteBoardUrl)
                .AddUrlSegment("id", _createdBoardId);
            var response = _client.Delete(request);
            ClassicAssert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            ClassicAssert.AreEqual(string.Empty, JToken.Parse(response.Content).SelectToken("_value").ToString());

            request = RequestWithAuth(CardsEndpoints.GetAllBoardsUrl)
                .AddUrlSegment("member", UrlParamValues.Username);
            response = _client.Get(request);
            var responseContent = JToken.Parse(response.Content);
            ClassicAssert.False(responseContent.Children().Select(token => token.SelectToken("id").ToString()).Contains(_createdBoardId));
        }
    }
}
