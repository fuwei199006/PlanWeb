﻿using Core.Cache;
using Core.Service;
using Plain.Dto;
using Plain.Model.Models;
using Plain.Model.Models.Model;
using System.Collections.Generic;
using System.Linq;
using Plain.BLL.ArticleService;

namespace Plain.Web
{
    public class CmsCommentCache
    {
        public List<Basic_Article> Articles
        {
            get
            {
                return CacheContext.Get(CacheKey.ArticleList,
                     () => ServiceContext.Current.CreateService<IArticleService>().GetArticles());
            }
        }

        public static CmsArticleCache Current
        {
            get
            {
                return CacheContext.GetItem<CmsArticleCache>();
            }
        }
        public List<Basic_Article> this[string key]
        {
            get
            {
                return CacheContext.Get(key,
                     () => Articles.Where(r => r.Category == key).ToList());
            }
        }

    }
}