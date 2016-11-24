using System.Web.Mvc;
using Framework.Web;

namespace Plain.UI.Controllers
{
    public class HomeController : BaseController
    {

 
        [PermessionIgnore]
        // GET: Home
        public ActionResult Index()
        {
              return View();
        }
    }
}