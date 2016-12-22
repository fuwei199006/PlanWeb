using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.Web;
using Plain.BLL.Article;
using Plain.BLL.CommitService;
using Core.Service;

namespace Plain.CMS.Controllers
{
    public class CmsHomeController : BaseController
    {
        private ICommitService _commitService;

        public CmsHomeController()
        {
            _commitService = ServiceContext.Current.CreateService<ICommitService>();
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
            ViewBag.CommitList = _commitService.GetCommitListById(article.Id);
            
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