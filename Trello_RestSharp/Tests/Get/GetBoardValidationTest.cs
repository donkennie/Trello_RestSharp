using System.Net;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using Trello_RestSharp.Arguments.Holders;
using Trello_RestSharp.Arguments.Providers;
using Trello_RestSharp.Consts;

namespace Trello_RestSharp.Tests.Get
{
    public class GetBoardsValidationTest : BaseTest
    {

        [Test]
        [TestCaseSource(typeof(BoardIdValidationArgumentsProvider))]
        public void CheckGetBoardWithInvalidId(BoardIdValidationArgumentsHolder validationArguments)
        {
            var request = RequestWithAuth(CardsEndpoints.GetBoardUrl)
                        .AddUrlSegment("id", UrlParamValues.ExistingBoardId)
                        .AddOrUpdateParameters(validationArguments.PathParams);
            var response = _client.Get(request);
            ClassicAssert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            ClassicAssert.AreEqual("invalid id", response.Content);
        }

        [Test]
        [TestCaseSource(typeof(AuthValidationArgumentsProvider))]
        public void CheckGetBoardWithInvalidAuth(AuthValidationArgumentsHolder validationArguments)
        {
            var request = new RestRequest(CardsEndpoints.GetBoardUrl)
                .AddUrlSegment("id", UrlParamValues.ExistingBoardId)
                .AddOrUpdateParameters(validationArguments.AuthParams);
            var response = _client.Get(request);
            ClassicAssert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            ClassicAssert.AreEqual("unauthorized permission requested", response.Content);
        }

        [Test]
        public void CheckGetBoardWithAnotherUserCredentials()
        {
            var request = new RestRequest(CardsEndpoints.GetBoardUrl)
                .AddOrUpdateParameters(UrlParamValues.AnotherUserAuthQueryParams)
                .AddUrlSegment("id", UrlParamValues.ExistingBoardId);
            var response = _client.Get(request);
            ClassicAssert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            ClassicAssert.AreEqual("invalid token", response.Content);
        }
    }
}