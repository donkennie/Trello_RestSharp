using System.Net;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using Trello_RestSharp;
using Trello_RestSharp.Arguments.Holders;

namespace _07GetMethodValidation
{
    public class GetBoardsValidationTest : BaseTest
    {
        
        [Test]
        public void CheckGetBoardWithInvalidId(BoardIdValidationArgumentsHolder validationArguments)
        {
            var request = RequestWithAuth("/1/boards/{id}")
                        .AddOrUpdateParameters(validationArguments.PathParams);
            var response = _client.Get(request);
            ClassicAssert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            ClassicAssert.AreEqual("invalid id", response.Content);
        }

        [Test]
        public void CheckGetBoardWithInvalidAuth()
        {
            var request = new RestRequest("/1/boards/{id}")
                .AddUrlSegment("id", "61fe437419cdd87656ce9fa6");
            var response = _client.Get(request);
            ClassicAssert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            ClassicAssert.AreEqual("unauthorized permission requested", response.Content);
        }

        [Test]
        public void CheckGetBoardWithAnotherUserCredentials()
        {
            var request = new RestRequest("/1/boards/{id}")
                .AddQueryParameter("key", "8b32218e6887516d17c84253faf967b6")
                .AddQueryParameter("token", "492343b8106e7df3ebb7f01e219cbf32827c852a5f9e2b8f9ca296b1cc604955")
                .AddUrlSegment("id", "61fe437419cdd87656ce9fa6");
            var response = _client.Get(request);
            ClassicAssert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            ClassicAssert.AreEqual("invalid token", response.Content);
        }
    }
}