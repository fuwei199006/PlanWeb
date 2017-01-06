namespace Tools.Server
{
    internal interface IHttpHandler
    {
        void ProcessRequest(HttpContext context);
    }
}