using System.Collections.Generic;

namespace TfsApiBatchImport
{
    public class BatchRequest
    {
        public string method { get; set; }
        public Dictionary<string, string> headers { get; set; }
        public object[] body { get; set; }
        public string uri { get; set; }
    }
}
