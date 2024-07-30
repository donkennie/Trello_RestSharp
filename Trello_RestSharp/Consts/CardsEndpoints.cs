using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello_RestSharp.Consts
{
    public static class CardsEndpoints
    {
        public const string GetAllBoardsUrl = "/1/members/{member}/boards";
        public const string GetBoardUrl = "/1/boards/{id}";

        public const string CreateBoardUrl = "/1/boards";

        public const string DeleteBoardUrl = "/1/boards/{id}";
    }
}
