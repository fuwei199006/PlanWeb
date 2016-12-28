﻿using System;
using System.Collections.Generic;
using System.Linq;
using Plain.Dto.Request;
using Plain.Model.Models;
using Plain.Model.Models.Model;
using Plain.Dto;

namespace Plain.BLL.Article
{
    public class ArticleService:BaseService<Basic_Article>,IArticleService
    {
        public List<Basic_Article> GetArticlesByCategory(string category)
        {
            
            return
                this.LoadEntitiesNoTracking(r => r.Category == category && (r.ArticleStatus ==(int) ArticleStatus.Enable|| r.ArticleStatus == (int)ArticleStatus.InUsing))
                    .OrderByDescending(r => r.ModifyTIme)
                    .ToList();
        }

        /// <summary>
        /// CMS取数据
        /// </summary>
        /// <returns></returns>
        public List<Basic_Article> GetArticles()
        {
          return this.LoadEntitiesNoTracking(r=>r.ArticleStatus== (int)ArticleStatus.InUsing).ToList();
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

        /// <summary>
        /// 失效正在使用的文章
        /// </summary>
        public void DisableUsingArticle()
        {
            var articleList = this.LoadEntities(r => r.ArticleStatus == 2);
            foreach (var item in articleList)
            {
                item.ArticleStatus =(int) ArticleStatus.LostUsing;//说明已经失效
            }

            this.UpdateRang(articleList);
        }
    }
}