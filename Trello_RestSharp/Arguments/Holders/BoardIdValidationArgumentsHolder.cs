using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Trello_RestSharp.Arguments.Holders
{
    public class BoardIdValidationArgumentsHolder
    {
        public IEnumerable<Parameter> PathParams { get; set; }

        public string ErrorMessage { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
