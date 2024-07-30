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

namespace Trello_RestSharp.Tests.Create
{
    public class CreateBoardValidationTest : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BoardNameValidationArgumentsProvider))]
        public void CheckCreateBoardWithInvalidName(IDictionary<string, object> bodyParams)
        {
            var request = RequestWithAuth(CardsEndpoints.CreateBoardUrl)
                .AddJsonBody(bodyParams);
            var response = _client.Post(request);

            ClassicAssert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            ClassicAssert.AreEqual("invalid value for name", response.Content);
        }

        [Test]
        [TestCaseSource(typeof(AuthValidationArgumentsProvider))]
        public void CheckGetBoardWithInvalidAuth(AuthValidationArgumentsHolder validationArguments)
        {
            var request = RequestWithoutAuth(CardsEndpoints.CreateBoardUrl)
                .AddOrUpdateParameters(validationArguments.AuthParams)
                .AddJsonBody(new Dictionary<string, string> { { "name", "New item" } });
            var response = _client.Post(request);
            ClassicAssert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            ClassicAssert.AreEqual(validationArguments.ErrorMessage, response.Content);
        }
    }
}
