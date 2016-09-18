﻿using System.Collections.Generic;
using System.Linq;
using Plain.Model.Models;

namespace Plain.BLL.Article
{
    public class ArticleService:BaseService<Basic_Article>,IArticleService
    {
        public List<Basic_Article> GetArticlesByCategory(string category)
        {
            return
                this.CurrentResposity.GetListNoTracking(r => r.Category == category && r.ArticleStatus == 1)
                    .OrderByDescending(r => r.ModifyTIme)
                    .ToList();
        }

        public List<Basic_Article> GetArticles()
        {
          return this.CurrentResposity.GetListNoTracking(r=>r.ArticleStatus==1);
        }

        public Basic_Article GetArticlesById(int id)
        {
            return this.CurrentResposity.GetByIdNoTracking(id);
        }

        public void AddArticleList(List<Basic_Article> articles)
        {
              this.CurrentResposity.AddRange(articles);
        }
    }
}