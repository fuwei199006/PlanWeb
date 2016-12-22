﻿using System.Collections.Generic;
using Plain.Model.Models;
using Plain.Model.Models.Model;
using Plain.Dto.Request;

namespace Plain.BLL.Article
{
    public interface IArticleService : IBaseService<Basic_Article>
    {
        List<Basic_Article> GetArticlesByCategory(string category);
        List<Basic_Article> GetArticles();
        List<Basic_Article> GetArticlePage(ArticleRequest request);
        Basic_Article GetArticlesById(int id);
        Basic_Article UpdateArticle(Basic_Article article);

        void AddArticleList(List<Basic_Article> articles);

    }
}