using Plain.BLL.Article;
using Plain.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plain.UI.Areas.CMS.Controllers
{
    public class ArticleController : Controller
    {

        public readonly IArticleService _ArticleService;
        public ArticleController(IArticleService ArticleService)
        {
            _ArticleService = ArticleService;
        }
        // GET: CMS/CMS
        public ActionResult Index(ArticleRequest request)
        {
            var articleList = _ArticleService.GetArticlePage(request);
            return View(articleList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Edit(int id,FormCollection form)
        {
            return View();
        }

        public ActionResult Delete(List<int> ids)
        {
            return View();
        }
    }
}