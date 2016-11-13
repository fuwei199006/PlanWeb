using System.Web.Mvc;

namespace Framework.Web
{
    public class PlainPageView<T>  : WebViewPage<T>
    {
        public string UserName { get; set; }
        public override void Execute()
        {
             
        }
    }
}