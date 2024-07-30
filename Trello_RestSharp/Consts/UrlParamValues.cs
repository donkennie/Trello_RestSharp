using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello_RestSharp.Consts
{
    public static class UrlParamValues
    {
        public const string ValidKey = "fb04999a731923c2e3137153b1ad5de0";
        public const string ValidToken = "b73120fb537fceb444050a2a4c08e2f96f47389931bd80253d2440708f2a57e1";

        public static IEnumerable<Parameter> AuthQueryParams = new[]
        {
            Parameter.CreateParameter("key", ValidKey, ParameterType.QueryString),
            Parameter.CreateParameter("token", ValidToken, ParameterType.QueryString)
        };

        public static IEnumerable<Parameter> AnotherUserAuthQueryParams = new[]
        {
            Parameter.CreateParameter("key", "8b32218e6887516d17c84253faf967b6", ParameterType.QueryString),
            Parameter.CreateParameter("token", "492343b8106e7df3ebb7f01e219cbf32827c852a5f9e2b8f9ca296b1cc604955", ParameterType.QueryString)
        };

        public const string ExistingBoardId = "61fe437419cdd87656ce9fa6";

        public const string Username = "learnpostman";
    }
}
