using NUnit.Framework;
using RestSharp;

namespace Trello_RestSharp
{
    public class BaseTest
    {
        protected static IRestClient _client;

        [OneTimeSetUp]
        public static void InitializeRestClient() =>
            _client = new RestClient("https://api.trello.com");

        protected RestRequest RequestWithAuth(string resource) =>
          new RestRequest(resource)
              .AddQueryParameter(name: "key", value: "3d163ab039bdfde417d8694a031fcdb0")
              .AddQueryParameter(name: "token", value: "ATTAb8f33b16f11bdddbaeec4e7d0ef356624dfbc5a514030064601ee9bafc6a324226CF6654");

        protected RestRequest RequestWithoutAuth(string resource) =>
            new RestRequest(resource);
    }
}
