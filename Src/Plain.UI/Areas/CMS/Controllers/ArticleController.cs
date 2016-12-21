using Plain.BLL.Article;
using Plain.Dto;
using Plain.Dto.Request;
using Plain.Model.Models.Model;
using Plain.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plain.UI.Areas.CMS.Controllers
{
    public class ArticleController : BaseController
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

        public ActionResult Edit(int id, FormCollection form)
        {
            return View();
        }


        public ActionResult EditCategory(int id)
        {
            SetDropEnumViewData<ArticleType>(WebKeys.ArticleType);
            SetDropEnumViewData<StatusType>(WebKeys.ArticleStatu);
            var article = _ArticleService.GetArticlesById(id);
            return View(article);
        }

        [HttpPost]
        public ActionResult EditCategory(int id, FormCollection formCollect)
        {
            var article = _ArticleService.GetArticlesById(id);
            TryUpdateModel<Basic_Article>(article);
            _ArticleService.UpdateArticle(article);
            AdminCacheContext.ArticleItems.Clear();
            return this.RefreshParent();
        }
        public ActionResult Delete(List<int> ids)
        {
            return View();
        }
    }
}