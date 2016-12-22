﻿using System;
using System.Collections.Generic;
using System.Linq;
using Plain.Dto.Request;
using Plain.Model.Models;
using Plain.Model.Models.Model;

namespace Plain.BLL.Article
{
    public class ArticleService:BaseService<Basic_Article>,IArticleService
    {
        public List<Basic_Article> GetArticlesByCategory(string category)
        {
            
            return
                this.LoadEntitiesNoTracking(r => r.Category == category && r.ArticleStatus == 1)
                    .OrderByDescending(r => r.ModifyTIme)
                    .ToList();
        }

        public List<Basic_Article> GetArticles()
        {
          return this.LoadEntitiesNoTracking(r=>r.ArticleStatus==1).ToList();
        }

        public Basic_Article GetArticlesById(int id)
        {
            return this.GetEntityByIdNoTracking(id);
        }

        public void AddArticleList(List<Basic_Article> articles)
        {
              this.AddRange(articles);
        }

        public List<Basic_Article> GetArticlePage(ArticleRequest request)
        {
            if (string.IsNullOrEmpty(request.Content))
            {
                return this.LoadEntitiesByPage(r => true, r => r.CreateTime, request.PageSize, request.PageIndex);
            }
            return this.LoadEntitiesByPage(r => r.Title.Contains(request.Content) || r.Content.Contains(request.Content)||r.Position.Contains(request.Content), r => r.CreateTime, request.PageSize, request.PageIndex);
        }

        public Basic_Article UpdateArticle(Basic_Article article)
        {
            return this.Update(article);
        }
    }
}