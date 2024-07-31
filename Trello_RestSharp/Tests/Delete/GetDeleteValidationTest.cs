using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Trello_RestSharp.Arguments.Holders;
using Trello_RestSharp.Arguments.Providers;
using Trello_RestSharp.Consts;

namespace Trello_RestSharp.Tests.Delete
{
    public class GetDeleteValidationTest : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BoardIdValidationArgumentsProvider))]
        public void CheckDeleteBoardWithInvalidId(BoardIdValidationArgumentsHolder validationArguments)
        {
            var request = RequestWithAuth(CardsEndpoints.DeleteBoardUrl)
                .AddOrUpdateParameters(validationArguments.PathParams);
            var response = _client.Delete(request);
            ClassicAssert.AreEqual(validationArguments.StatusCode, response.StatusCode);
            ClassicAssert.AreEqual(validationArguments.ErrorMessage, response.Content);
        }

        [Test]
        [TestCaseSource(typeof(AuthValidationArgumentsProvider))]
        public void CheckDeleteBoardWithInvalidAuth(AuthValidationArgumentsHolder validationArguments)
        {
            var request = RequestWithoutAuth(CardsEndpoints.DeleteBoardUrl)
                .AddUrlSegment("id", UrlParamValues.ExistingBoardId)
                .AddOrUpdateParameters(validationArguments.AuthParams);
            var response = _client.Delete(request);
            ClassicAssert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            ClassicAssert.AreEqual(validationArguments.ErrorMessage, response.Content);
        }

        [Test]
        public void CheckDeleteBoardWithAnotherUserCredentials()
        {
            var request = RequestWithoutAuth(CardsEndpoints.DeleteBoardUrl)
                .AddOrUpdateParameters(UrlParamValues.AnotherUserAuthQueryParams)
                .AddUrlSegment("id", UrlParamValues.ExistingBoardId);
            var response = _client.Delete(request);
            ClassicAssert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            ClassicAssert.AreEqual("invalid token", response.Content);
        }
    }
}
