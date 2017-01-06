namespace Tools.Server
{
    internal class HttpContext
    {
        private string httpHeader;

        public HttpContext(string httpHeader)
        {
            this.HttpRespone = new HttpRespone();
            this.HttpRequest = new HttpRequest(httpHeader);
        }
        public HttpRequest HttpRequest { get; internal set; }
        public HttpRespone HttpRespone { get; internal set; }
    }
}