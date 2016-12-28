using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.Web;
using Plain.BLL.Article;
using Plain.BLL.CommitService;
using Core.Service;
using Plain.CMS.ActionFilters;
using Plain.Model.Models.Model;
using Plain.Web;

namespace Plain.CMS.Controllers
{
    public class CmsHomeController : BaseController
    {
        private readonly ICommitService _commitService;

        public CmsHomeController()
        {
            _commitService = ServiceContext.Current.CreateService<ICommitService>();
        }

        [AuthorizeIgnore]
        [SingalLogin]
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
            //ViewBag.CommitList = _commitService.GetCommitListById(article.Id);
            
            return View(article);
        }

        [HttpGet]
         [AuthorizeIgnore]
        public ViewResult Page(string key)
        {
            ViewBag.key = key;
            return View();
        }

        public JsonResult AddCommit(string content, int articleId, int type)
        {
            var commmit = new Basic_Commit
            {
                Content = content,
                ArticleId = articleId,
                CommitType = type,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now,
                CommitUserId = AdminUserContext.Current.BasicUserInfo.Id,
                CommitUserName = AdminUserContext.Current.BasicUserInfo.LoginName
                
            };
          var returnEntity=  _commitService.AddCommit(commmit);
            return Json(returnEntity);
        }
        [AuthorizeIgnore]
        public JsonResult GetCommit(int articleId)
        {
            return Json(_commitService.GetCommitListById(articleId));
        }
    }
}