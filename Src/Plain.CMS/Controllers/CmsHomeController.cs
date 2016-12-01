using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.Web;
using Plain.BLL.Article;

namespace Plain.CMS.Controllers
{
    public class CmsHomeController : BaseController
    {
        private IArticleService _articleService;

        public CmsHomeController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [AuthorizeIgnore]
        // GET: CMS/CmsHome
        public ActionResult Index()
        {
            
            return View();
        }

        [AuthorizeIgnore]
        // GET: CMS/CmsHome
        public ActionResult ArticleView(int id)
        {
            var article = AdminCacheContext.ArticleItems.Articles.FirstOrDefault(r => r.Id == id);
            //_articleService.GetArticlesById(id);
            return View(article);
        }

        [HttpGet]
         [AuthorizeIgnore]
        public ViewResult Page(string key)
        {
            ViewBag.key = key;
            return View();
        }
    }
}