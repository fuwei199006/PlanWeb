using System.Collections.Generic;
using Plain.Model.Models;

namespace Plain.BLL.Article
{
    public interface IArticleService : IBaseService<Basic_Article>
    {
        List<Basic_Article> GetArticlesByCategory(string category);
        Basic_Article GetArticlesById(int id);

    }
}