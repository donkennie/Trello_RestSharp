using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello_RestSharp.Arguments.Providers
{
    public class BoardNameValidationArgumentsProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new Dictionary<string, object> {{"name", 12345}}
            };
            yield return new object[]
            {
                ImmutableDictionary<string, object>.Empty
            };
        }
    }
}
