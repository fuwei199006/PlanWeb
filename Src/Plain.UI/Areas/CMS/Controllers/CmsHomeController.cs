using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.Web;
using Plain.BLL.Article;
using Plain.UI.Controllers;

namespace Plain.UI.Areas.CMS.Controllers
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
            var article = CacheContext.ArticleItems.Articles.FirstOrDefault(r => r.Id == id);
            //_articleService.GetArticlesById(id);
            return View(article);
        }


        public PartialViewResult Page(int pageIndex)
        {
            return PartialView();
        }
    }
}