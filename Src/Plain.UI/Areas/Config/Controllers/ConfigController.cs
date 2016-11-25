using Plain.BLL.ConfigService;
using System.Web.Mvc;

namespace Plain.UI.Areas.Config.Controllers
{
    public class ConfigController : Controller
    {

        private readonly IConfigService _configService;
        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }
        // GET: Config/Config
        public ActionResult Index()
        {
            var dbConfig = _configService.GetDaoConfig();
            return View(dbConfig);
        }
    }
}