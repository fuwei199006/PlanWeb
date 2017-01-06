namespace Tools.Server
{
    public class HttpRequest
    {
        private string httpHeader;

        public HttpRequest(string httpHeader)
        {
            this.httpHeader = httpHeader;
        }

        public string FilePath { get; internal set; }
        public string Method { get; internal set; }
        public string RequestClass { get; internal set; }

    }
}