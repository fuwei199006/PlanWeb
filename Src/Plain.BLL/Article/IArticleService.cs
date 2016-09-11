using System.Collections.Generic;
using Plain.Model.Models;

namespace Plain.BLL.Article
{
    public interface IArticleService : IBaseService<Basic_Article>
    {
        List<Basic_Article> GetArticlesByCategory(string category);
        List<Basic_Article> GetArticles();
        Basic_Article GetArticlesById(int id);

        void AddArticleList(List<Basic_Article> articles);

    }
}