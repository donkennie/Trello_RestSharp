﻿using RestSharp;
using System.Collections;
using System.Net;
using Trello_RestSharp.Arguments.Holders;

namespace Trello_RestSharp.Arguments.Providers
{
    public class BoardIdValidationArgumentsProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new BoardIdValidationArgumentsHolder
                {
                    ErrorMessage = "invalid id",
                    StatusCode = HttpStatusCode.BadRequest,
                    PathParams = new[] { Parameter.CreateParameter("id", "invalid", ParameterType.UrlSegment)}
                }
            };
            yield return new object[]
            {
                new BoardIdValidationArgumentsHolder
                {
                    ErrorMessage = "The requested resource was not found.",
                    StatusCode = HttpStatusCode.NotFound,
                    PathParams = new[] { Parameter.CreateParameter("id", "60d847d9aad2437cb984f8e1", ParameterType.UrlSegment)}
                }
            };
        }
    }
}
